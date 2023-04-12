using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PackUriSample.ViewModels
{
    /// <summary>
    /// MainWindowViewModel
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManeger;
        private string _title = "Pack Uri Sample";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        /// <summary>
        /// 네비게이트 메뉴 커맨드
        /// </summary>
        public ICommand NavigateMenuCommand { get; set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManeger = regionManager;
            Init();
        }

        private void Init()
        {
            NavigateMenuCommand = new DelegateCommand<string>(OnNavigateMenu);
            _regionManeger.RegisterViewWithRegion("ContentRegion", "CakeView");
        }
        /// <summary>
        /// 네비게이트 메뉴
        /// </summary>
        /// <param name="viewName"></param>
        private void OnNavigateMenu(string viewName)
        {
            if(string.IsNullOrEmpty(viewName))
            {
                return;
            }
            _regionManeger.RequestNavigate("ContentRegion", viewName);
        }
    }
}
