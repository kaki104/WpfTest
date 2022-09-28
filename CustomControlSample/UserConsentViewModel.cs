using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControlSample
{
    /// <summary>
    /// 사용자 동의 뷰모델
    /// </summary>
    public class UserConsentViewModel : ObservableObject
    {
        /// <summary>
        /// 서비스 프로바이더
        /// </summary>
        private readonly IServiceProvider _serviceProvider;
        /// <summary>
        /// 기본 생성자
        /// </summary>
        public UserConsentViewModel()
        {

        }
        /// <summary>
        /// 런타임 생성자
        /// </summary>
        /// <param name="serviceProvider">서비스 프로바이더 주입</param>
        public UserConsentViewModel(IServiceProvider serviceProvider) : this()
        {
            _serviceProvider = serviceProvider;
            //App.Current.Services.GetService를 직접 사용하는 코드는 가능하면 사용하지 않습니다.
        }
    }
}
