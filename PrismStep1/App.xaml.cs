using Prism.Ioc;
using PrismStep1.Views;
using System.Diagnostics;
using System.Windows;

namespace PrismStep1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            var win1 = Container.Resolve<MainWindow>();
            var win2 = Container.Resolve<MainWindow>();
            if(win1.Equals(win2))
            {
                Debug.WriteLine("Equals");
            }
            else
            {
                Debug.WriteLine("Not Equals");
            }
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<MainWindow>();
        }
    }
}
