using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;

namespace PrismStep2.ViewModels
{
    /// <summary>
    /// MainWindowViewModel
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// ContainerProvider
        /// </summary>
        private readonly IContainerProvider _containerProvider;

        private IList<string> _navigationNames;
        /// <summary>
        /// Navigation Names
        /// </summary>
        public IList<string> NavigationNames
        {
            get { return _navigationNames; }
            set { SetProperty(ref _navigationNames, value); }
        }

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private string _selectedNavigationName;
        /// <summary>
        /// 선택된 네비게이션 할 뷰이름
        /// </summary>
        public string SelectedNavigationName
        {
            get { return _selectedNavigationName; }
            set { SetProperty(ref _selectedNavigationName, value); }
        }
        /// <summary>
        /// NavigateCommand
        /// </summary>
        public ICommand NavigateCommand { get; set; }
        /// <summary>
        /// 기본 생성자
        /// </summary>
        public MainWindowViewModel()
        {
        }
        /// <summary>
        /// 런타임 생성자
        /// </summary>
        /// <param name="containerProvider"></param>
        public MainWindowViewModel(IContainerProvider containerProvider)
        {
            //프리즘에서 사용하고 있는 IoC Container를 생성자 주입 후 로컬 변수로 등록하고 사용합니다.
            _containerProvider = containerProvider;
            //NavigateCommand 생성 - 꼭 생성자에서 만들 필요는 없지만 클래스가 만들어진 후 빠르게
            //생성하는 것이 좋습니다.
            NavigateCommand = new DelegateCommand(OnNavigate, CanNavigate)
                                .ObservesProperty(() => SelectedNavigationName);
            //네비게이션 할 View 이름들
            NavigationNames = new List<string>
            {
                "Sample1View",
                "Sample2View"
            };
        }
        /// <summary>
        /// NavigateCommand를 View에서 호출했을 때 실행될 메서드
        /// </summary>
        /// <param name="obj"></param>
        private void OnNavigate()
        {
            Debug.WriteLine($"OnNavigate : {SelectedNavigationName}");
        }
        /// <summary>
        /// NavigateCommand를 사용할 수 있는지 여부반환
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool CanNavigate()
        {
            //SelectedNavigationName가 빈값이 아닌 경우에만 사용 가능
            return string.IsNullOrEmpty(SelectedNavigationName) == false;
        }
    }
}
