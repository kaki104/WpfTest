using System.Windows.Controls;

namespace CustomControlSample
{
    /// <summary>
    /// 사용자 동의 뷰
    /// </summary>
    public partial class UserConsent : UserControl
    {
        public UserConsent()
        {
            InitializeComponent();
        }

        public UserConsent(UserConsentViewModel viewModel) : this()
        {
            ViewModel = viewModel;
        }

        public UserConsentViewModel ViewModel
        {
            get =>
                //프로젝트 속성이 null 허용이 아니라 이렇게 처리했습니다
                (UserConsentViewModel)DataContext;
            set => DataContext = value;
        }
    }
}
