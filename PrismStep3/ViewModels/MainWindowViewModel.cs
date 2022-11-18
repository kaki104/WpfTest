using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace PrismStep3.ViewModels
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
        /// Person생성 커맨드
        /// </summary>
        public ICommand CreatePersonCommand { get; set; }
        /// <summary>
        /// Person생성2 커맨드
        /// </summary>
        public ICommand CreatePerson2Command { get; set; }
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
            CreatePersonCommand = new DelegateCommand(OnCreatePerson);
            CreatePerson2Command = new DelegateCommand(OnCreatePerson2);
            //네비게이션 할 View 이름들
            NavigationNames = new List<string>
            {
                "Sample1View",
                "Sample2View"
            };
        }

        private void OnCreatePerson2()
        {
            var kaki105 = _containerProvider.Resolve<Person>("kaki105");
            var kaki106 = _containerProvider.Resolve<Person>("kaki106");
            ShowMessage(kaki105, kaki106, "Create Person2");
        }

        private void ShowMessage(object one, object two, string title = "")
        {
            if(one == null || two == null)
            {
                MessageBox.Show("Both objects must be not null", title);
                return;
            }
            if (one.Equals(two))
            {
                MessageBox.Show("It's the same instance", title);
            }
            else
            {
                MessageBox.Show("They are different instances", title);
            }
        }

        /// <summary>
        /// Person 생성
        /// </summary>
        private void OnCreatePerson()
        {
            var person1 = _containerProvider.Resolve<Person>();
            var person2 = _containerProvider.Resolve<Person>();
            ShowMessage(person1, person2, "Create Person");
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
