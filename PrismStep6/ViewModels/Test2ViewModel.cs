using Prism;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PrismStep6.ViewModels
{
    public class Test2ViewModel : BindableBase, INavigationAware, IActiveAware
    {
        public string Header { get; set; }
        private IList<string> _messages = new ObservableCollection<string>();
        public IList<string> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }
        /// <summary>
        /// 액티브 체인지 이벤트
        /// </summary>
        public event EventHandler IsActiveChanged;
        private bool _isActive;
        /// <summary>
        /// IsActive 활성화 여부 프로퍼티 - IActiveAware
        /// </summary>
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value, () => Messages.Add($"{GetType().Name} IsActive : {IsActive}"));
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
