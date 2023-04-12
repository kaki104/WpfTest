using PackUriSample.Module.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace PackUriSample.Module
{
    /// <summary>
    /// 모듈 초기화 클래스
    /// </summary>
    public class PackUriSampleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<IceCreamView>();
        }
    }
}