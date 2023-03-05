using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using PrismStep7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismStep7.ViewModels
{
    /// <summary>
    /// 홈 뷰모델
    /// </summary>
    public class HomeViewModel : BindableBase
    {
        private readonly IContainerProvider _containerProvider;
        private readonly IRegionManager _regionManager;

        private IAppContext _appContext;
        /// <summary>
        /// AppContext
        /// </summary>
        public IAppContext AppContext
        {
            get { return _appContext; }
            set { SetProperty(ref _appContext, value); }
        }
        /// <summary>
        /// 디자인 타임 생성자
        /// </summary>
        public HomeViewModel()
        {

        }
        /// <summary>
        /// 런타임 생성자
        /// </summary>
        public HomeViewModel(IContainerProvider containerProvider, IRegionManager regionManager, 
            IAppContext appContext)
        {
            _containerProvider = containerProvider;
            _regionManager = regionManager;
            AppContext = appContext;
        }
    }
}
