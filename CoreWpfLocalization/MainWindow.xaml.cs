using System.Windows;
using System.Windows.Controls;

namespace CoreWpfLocalization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DynamicResource _dr;

        public MainWindow()
        {
            InitializeComponent();
            _dr = App.Current.Resources["DR"] as DynamicResource;
            _dr.LanguageChanged += _dr_LanguageChanged;
        }

        private void _dr_LanguageChanged(object sender, string e)
        {
            Title = _dr["WRD_WindowTitle"];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            _dr.ChangeLanguage(button.Content.ToString());
        }
    }
}
