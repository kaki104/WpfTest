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
        private static IContainerProvider _containerProvider;
        /// <summary>
        /// 컨테이너 프로바이더 - 생성자 인젝션 할 수 없는 환경에서 사용하기 위해 추가
        /// </summary>
        public static IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _containerProvider = Container;

            //AppContext 싱글톤으로 등록
            _ = containerRegistry.RegisterSingleton<IAppContext, AppContext>();

            //Region Navigation할 화면 등록
            containerRegistry.RegisterForNavigation(typeof(Login), nameof(Login));
            containerRegistry.RegisterForNavigation(typeof(Home), nameof(Home));
        }
    }
}
