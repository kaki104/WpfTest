using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using PrismStep7.Models;
using PrismStep7.Views;
using System;
using System.Windows.Input;

namespace PrismStep7.ViewModels
{
    /// <summary>
    /// 홈 뷰모델
    /// </summary>
    public class HomeViewModel : BindableBase
    {
        private readonly IContainerProvider _containerProvider;
        private readonly IRegionManager _regionManager;

        private IAppContext _appContext;
        /// <summary>
        /// AppContext
        /// </summary>
        public IAppContext AppContext
        {
            get { return _appContext; }
            set { SetProperty(ref _appContext, value); }
        }
        private string _viewName;
        /// <summary>
        /// ContentControl에 생성할 뷰이름
        /// </summary>
        public string ViewName
        {
            get { return _viewName; }
            set { SetProperty(ref _viewName, value); }
        }
        private Type _viewType;
        /// <summary>
        /// ControlControl에 생성할 뷰유형
        /// </summary>
        public Type ViewType
        {
            get { return _viewType; }
            set { SetProperty(ref _viewType, value); }
        }
        private string _viewKind;
        /// <summary>
        /// ControlControl에 생성할 뷰 종류
        /// </summary>
        public string ViewKind
        {
            get { return _viewKind; }
            set { SetProperty(ref _viewKind, value); }
        }
        /// <summary>
        /// Behavior커맨드
        /// </summary>
        public ICommand BehaviorCommand { get; set; }
        /// <summary>
        /// Template커맨드
        /// </summary>
        public ICommand TemplateCommand { get; set; }
        /// <summary>
        /// 디자인 타임 생성자
        /// </summary>
        public HomeViewModel()
        {

        }
        /// <summary>
        /// 런타임 생성자
        /// </summary>
        public HomeViewModel(IContainerProvider containerProvider, IRegionManager regionManager,
            IAppContext appContext)
        {
            _containerProvider = containerProvider;
            _regionManager = regionManager;
            AppContext = appContext;

            Init();
        }

        private void Init()
        {
            BehaviorCommand = new DelegateCommand<string>(OnBehavior);
            TemplateCommand = new DelegateCommand<string>(OnTemplate);
        }

        private void OnTemplate(string para)
        {
            //ViewKind 값에 따라 미리 정의한 여러개의 화면을 넣을 수 있음
            ViewKind = para;
        }
        /// <summary>
        /// BehaviorCommand에 연결된 메서드
        /// </summary>
        /// <param name="para"></param>
        private void OnBehavior(string para)
        {
            switch (para)
            {
                case "Name":
                    //어셈블리 이름만 주면 인젝션 시킬 수 있기 때문에, 참조를 추가하지 않아도 생성 시킬 수 있음
                    ViewName = typeof(InjectionView).AssemblyQualifiedName;
                    break;
                case "Type":
                    //생성할 Type을 반환해야해서 참조가 필요
                    ViewType = typeof(InjectionView);
                    break;
            }
        }
    }
}
