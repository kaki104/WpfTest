using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ViewModelReuseSample.Views;

namespace ViewModelReuseSample.ViewModels
{
    /// <summary>
    /// 메인 뷰모델
    /// </summary>
    public class MainWindowViewModel : ObservableObject
    {
        private string _message = string.Empty;
        /// <summary>
        /// Message
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        /// <summary>
        /// MainWindow에서만 사용되는 커맨드
        /// </summary>
        public ICommand OpenSecondWindowCommand { get; set; }

        /// <summary>
        /// 기본 생성자
        /// </summary>
        public MainWindowViewModel()
        {
            Message = $"This is MainWindowViewModel\nGuid : {Guid.NewGuid()}";
            OpenSecondWindowCommand = new RelayCommand(OnOpenSecondWindow);
        }
        /// <summary>
        /// 버튼 클릭시 실행
        /// </summary>
        private void OnOpenSecondWindow()
        {
            var window = new SecondWindow();
            window.Show();
        }
    }
}
