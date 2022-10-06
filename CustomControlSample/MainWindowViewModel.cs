using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Input;

namespace CustomControlSample
{
    public class MainWindowViewModel : ObservableObject
    {
        private bool _isPopupOpen;
        /// <summary>
        /// 팝업 오픈
        /// </summary>
        public bool IsPopupOpen
        {
            get => _isPopupOpen;
            set => SetProperty(ref _isPopupOpen, value);
        }
        private object? _popupContent;
        /// <summary>
        /// 팝업 컨텐츠
        /// </summary>
        public object? PopupContent
        {
            get => _popupContent;
            set => SetProperty(ref _popupContent, value);
        }
        private string _message;
        /// <summary>
        /// 결과 출력용 메시지
        /// </summary>
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
        /// <summary>
        /// 서비스 프로바이더
        /// </summary>
        private readonly IServiceProvider _serviceProvider;
        /// <summary>
        /// 팝업 출력 커맨드
        /// </summary>
        public ICommand ShowPopupCommand { get; set; }
        /// <summary>
        /// Popup내부에서 호출할 닫기 커맨드
        /// </summary>
        public ICommand ClosePopupCommand { get; set; }

        public MainWindowViewModel()
        {

        }
        public MainWindowViewModel(IServiceProvider serviceProvider) : this()
        {
            //App.Current.Services.GetService를 직접 사용하지 않고, Injection 받아서 사용합니다.
            _serviceProvider = serviceProvider;

            ShowPopupCommand = new RelayCommand(OnShowPopup);
            ClosePopupCommand = new RelayCommand<bool>(b =>
                {
                    //결과 출력
                    Message = b ? "동의 했습니다." : "동의가 완료되지 않았습니다.";
                    IsPopupOpen = false;
                    PopupContent = null;
                });
        }
        /// <summary>
        /// 팝업 열기
        /// </summary>
        private void OnShowPopup()
        {
            IsPopupOpen = true;
            UserConsent? content = _serviceProvider.GetService<UserConsent>();
            if (content == null)
            {
                return;
            }
            content.Width = 300;
            content.Height = 200;
            if (content.DataContext is UserConsentViewModel viewModel)
            {
                viewModel.ClosePopupCommand = ClosePopupCommand;
            }
            PopupContent = content;
        }
    }
}
