using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows.Input;

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
        private bool _isUserConsent;
        /// <summary>
        /// 사용자 동의 여부
        /// </summary>
        public bool IsUserConsent
        {
            get => _isUserConsent;
            set => SetProperty(_isUserConsent, value,
                            callback =>
                            {
                                _isUserConsent = callback;
                                ((RelayCommand)SubmitCommand).NotifyCanExecuteChanged();
                            });
        }
        /// <summary>
        /// 제출 커맨드
        /// </summary>
        public ICommand SubmitCommand { get; set; }
        /// <summary>
        /// 팝업 닫기 커맨드 - MainWindowViewModel에서 연결
        /// </summary>
        public ICommand ClosePopupCommand { get; set; }
        /// <summary>
        /// 종료 커맨드
        /// </summary>
        public ICommand ExitCommand { get; set; }
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
            //App.Current.Services.GetService를 직접 사용하지 않고, Injection 받아서 사용합니다.
            _serviceProvider = serviceProvider;
            Init();
        }

        private void Init()
        {
            SubmitCommand = new RelayCommand(() =>
                {
                    ClosePopupCommand?.Execute(true);
                }, () => IsUserConsent);
            ExitCommand = new RelayCommand(() =>
                {
                    ClosePopupCommand?.Execute(false);
                });
        }
    }
}
