using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            //뷰모델 인스턴스 후 DataContext에 입력
            var vm = App.Current.Services.GetService(typeof(UserConsentViewModel)) as UserConsentViewModel;
            if(vm == null)
            {
                throw new NullReferenceException();
            }
            ViewModel = vm;
        }

        public UserConsentViewModel ViewModel 
        {
            get 
            { 
                //프로젝트 속성이 null 허용이 아니라 이렇게 처리했습니다
                return (UserConsentViewModel)DataContext; 
            }
            set { DataContext = value; } 
        }
    }
}
