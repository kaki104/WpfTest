using Prism.Ioc;
using PrismStep7.Models;
using PrismStep7.Views;
using System.Windows;

namespace PrismStep7
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //AppContext 싱글톤으로 등록
            containerRegistry.RegisterSingleton<IAppContext, AppContext>();

            //Region Navigation할 화면 등록
            containerRegistry.RegisterForNavigation(typeof(Login),nameof(Login));
            containerRegistry.RegisterForNavigation(typeof(Home), nameof(Home));
        }
    }
}
