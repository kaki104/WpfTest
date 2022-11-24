using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PrismStep4.ViewModels
{
    public class Test2ViewModel : BindableBase, INavigationAware
    {
        public string Header { get; set; }
        private IList<string> _messages = new ObservableCollection<string>();
        public IList<string> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }
        public Test2ViewModel()
        {
            Header = GetType().Name;
            Messages.Add(Header);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Messages.Add($"{GetType().Name} OnNavigatedTo - {navigationContext.NavigationService.Journal.CurrentEntry}");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Messages.Add($"{GetType().Name} OnNavigatedFrom");
        }
    }
}
