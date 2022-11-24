using Prism.Ioc;
using PrismStep4.Views;
using System.Windows;

namespace PrismStep4
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
            //네비게이션할 화면 등록
            containerRegistry.RegisterForNavigation<Test1View>();
            containerRegistry.RegisterForNavigation<Test2View>();
        }
    }
}
