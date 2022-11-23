using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows.Input;

namespace PrismStep4.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private readonly IRegionManager _regionManager;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ICommand NavigationCommand { get; set; }

        public MainWindowViewModel()
        {
            NavigationCommand = new DelegateCommand<string>(OnNavigation);
        }

        public MainWindowViewModel(IRegionManager regionManager) 
            : this()
        {
            _regionManager = regionManager;
        }

        private void OnNavigation(string para)
        {
            switch(para)
            {
                case "Back":
                    {
                        var journal = _regionManager.Regions["ContentRegion"].NavigationService.Journal;
                        if(journal.CanGoBack)
                        {
                            journal.GoBack();
                        }
                    }
                    break;
                default:
                    _regionManager.RequestNavigate("ContentRegion", para);
                    break;
            }
        }
    }
}
