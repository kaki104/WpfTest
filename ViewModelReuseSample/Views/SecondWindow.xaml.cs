using System.Windows;
using ViewModelReuseSample.ViewModels;

namespace ViewModelReuseSample.Views
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService(typeof(MainWindowViewModel));
        }
    }
}
