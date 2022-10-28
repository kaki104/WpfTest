using System.Windows;

namespace CustomControlSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(MainWindowViewModel viewModel) : this()
        {
            ViewModel = viewModel;
        }

        public MainWindowViewModel ViewModel
        {
            //프로젝트 속성이 null 허용이 아니라 이렇게 처리했습니다
            get => (MainWindowViewModel)DataContext;
            set => DataContext = value;
        }
    }
}
