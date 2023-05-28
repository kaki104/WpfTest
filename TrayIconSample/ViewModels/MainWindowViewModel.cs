using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace TrayIconSample.ViewModels
{
    /// <summary>
    /// 메인 윈도우 뷰모델
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// 트레이 아이콘
        /// </summary>
        private System.Windows.Forms.NotifyIcon _notifyIcon;

        private string _title = "Prism Application";
        /// <summary>
        /// 윈도우 닫기 버튼 클릭시 ..커맨드
        /// </summary>
        public ICommand ClosingCommand { get; set; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        /// <summary>
        /// 디자인타임 생성자
        /// </summary>
        public MainWindowViewModel()
        {
        }
        /// <summary>
        /// 런타임 생성자
        /// </summary>
        /// <param name="containerProvider"></param>
        public MainWindowViewModel(IContainerProvider containerProvider) : this()
        {
            Title = "Tray Sample";
            CreateTrayIcon("sample.ico", Title);
            Init();
        }

        private void Init()
        {
            ClosingCommand = new DelegateCommand<object>(OnClosing);
        }
        /// <summary>
        /// 윈도우 못닫게 해야함
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnClosing(object obj)
        {
            if (obj is not CancelEventArgs eventArgs)
            {
                return;
            }
            //트레이 아이콘이 존재하는 경우에만 숨김
            if (_notifyIcon != null)
            {
                Application.Current.MainWindow.Hide();
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
                eventArgs.Cancel = true;
            }
        }
        /// <summary>
        /// 트레이 아이콘 생성
        /// </summary>
        /// <param name="iconName"></param>
        /// <returns></returns>
        private void CreateTrayIcon(string iconName, string title)
        {
            //icon 파일은 임베디드 리소스로 설정
            System.Reflection.Assembly assembly = GetType().Assembly;
            string name = $"{assembly.GetName().Name}.Assets.{iconName}";
            using Stream stream = assembly.GetManifestResourceStream(name);
            _notifyIcon = new System.Windows.Forms.NotifyIcon
            {
                //icon을 생성하는 방법이 파일위치를 직접 입력하거나
                //스트림으로 입력하는 방법만 존재하기 때문에 icon을 임베디드 리소스로 저장해서 사용
                Icon = new System.Drawing.Icon(stream),
                Text = title
            };
            _notifyIcon.DoubleClick +=
                (s, e) =>
                {
                    OnOpenApplication();
                };
            _notifyIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            _ = _notifyIcon.ContextMenuStrip.Items.Add("Open", null, OnOpen);
            _ = _notifyIcon.ContextMenuStrip.Items.Add("Shutdown", null, OnExit);
            _notifyIcon.Visible = true;
        }
        /// <summary>
        /// 애플리케이션 열기
        /// </summary>
        private void OnOpenApplication()
        {
            Application.Current.MainWindow.Show();
            Application.Current.MainWindow.WindowState = WindowState.Normal;
        }
        /// <summary>
        /// Shutdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnExit(object sender, EventArgs e)
        {
            OnShutdown();
        }
        /// <summary>
        /// 열기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpen(object sender, EventArgs e)
        {
            OnOpenApplication();
        }
        /// <summary>
        /// 종료
        /// </summary>
        private void OnShutdown()
        {
            MessageBoxResult result = MessageBox.Show("Shutdown Ok?", "Confirm", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            //NotifyIcon dispose
            if (_notifyIcon != null)
            {
                _notifyIcon.Visible = false;
                _notifyIcon.Dispose();
                _notifyIcon = null;
            }
            //프로그램 종료
            Application.Current.Shutdown();
        }
    }
}
