using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfLocalization
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var resource = App.Current.Resources["DR"] as DynamicResource;
            if (resource != null)
            {
                resource.ChangeLanguage("ko-KR");
            }

            var view = new MainWindow();
            view.Show();
        }
    }
}
