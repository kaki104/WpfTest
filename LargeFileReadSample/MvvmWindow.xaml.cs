using System.Windows;

namespace LargeFileReadSample
{
    /// <summary>
    /// Interaction logic for MvvmWindow.xaml
    /// </summary>
    public partial class MvvmWindow : Window
    {
        public MvvmWindow()
        {
            InitializeComponent();
            DataContext = new MvvmViewModel();
        }
    }
}
