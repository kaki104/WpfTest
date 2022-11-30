using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;

namespace PrismStep5.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        /// <summary>
        /// Region관리자
        /// </summary>
        private readonly IRegionManager _regionManager;
        /// <summary>
        /// 타이틀
        /// </summary>
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        /// <summary>
        /// 네비게이션 커맨드
        /// </summary>
        public ICommand NavigationCommand { get; set; }
        /// <summary>
        /// Window Loaded 이벤트 발생시 실행되는 커맨드
        /// </summary>
        public ICommand LoadedCommand { get; set; }
        /// <summary>
        /// 기본 생성자
        /// </summary>
        public MainWindowViewModel()
        {
            NavigationCommand = new DelegateCommand<string>(OnNavigation);
        }

        /// <summary>
        /// 런타임 생성자
        /// </summary>
        /// <param name="regionManager"></param>
        public MainWindowViewModel(IRegionManager regionManager)
            : this()
        {
            //IRegionManager를 Injection 받아서 사용하기 위해 _regionManager에 연결합니다.
            _regionManager = regionManager;
            //ContentRegion에 Test1View를 등록 예약 시켜 놓습니다.
            _regionManager.RegisterViewWithRegion("ContentRegion", "Test1View");
        }
        /// <summary>
        /// NavigationCommand의 실행 메서드
        /// </summary>
        /// <param name="para"></param>
        private void OnNavigation(string para)
        {
            switch (para)
            {
                //Back이란 문자열이 들어오면..
                case "Back":
                    {
                        //Back을 구현하기 위해서 ContentRegion의 Journal을 가져오고, 뒤로가기가 가능한지 확인 후 실행
                        IRegionNavigationJournal journal = _regionManager.Regions["ContentRegion"]
                                                                .NavigationService.Journal;
                        if (journal.CanGoBack)
                        {
                            journal.GoBack();
                        }
                    }
                    break;
                //그외 일반 문자열이 들어오면    
                default:
                    //ContentRegion에 para가 지정하는 화면으로 네비게이트 해라
                    _regionManager.RequestNavigate("ContentRegion", para);
                    break;
            }
        }
    }
}
