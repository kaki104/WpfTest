using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using PrismStep7.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace PrismStep7.ViewModels
{
    /// <summary>
    /// 로그인 뷰모델
    /// </summary>
    public class LoginViewModel : BindableBase
    {
        private readonly IContainerProvider _containerProvider;
        private readonly IRegionManager _regionManager;

        private IAppContext _appContext;
        /// <summary>
        /// AppContext
        /// </summary>
        public IAppContext AppContext
        {
            get => _appContext;
            set => SetProperty(ref _appContext, value);
        }

        /// <summary>
        /// 로그인 커맨드
        /// </summary>
        public ICommand LoginCommand { get; set; }
        /// <summary>
        /// 디자인 타임 생성자
        /// </summary>
        public LoginViewModel()
        {

        }
        /// <summary>
        /// 런타임 생성자
        /// </summary>
        public LoginViewModel(IContainerProvider containerProvider, IRegionManager regionManager, IAppContext appContext)
        {
            _containerProvider = containerProvider;
            _regionManager = regionManager;
            AppContext = appContext;

            Init();
        }
        private void Init()
        {
            LoginCommand = new DelegateCommand(OnLogin);
        }
        private void OnLogin()
        {
            if (string.IsNullOrEmpty(AppContext.Id) || string.IsNullOrEmpty(AppContext.Name))
            {
                _ = MessageBox.Show("Please enter your ID and name.");
                return;
            }
            AppContext.Connection = DateTime.Now;
            _regionManager.RequestNavigate("ContentRegion", "Home");
        }
    }
}
