using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using PrismStep7.Models;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace PrismStep7.ViewModels
{
    public class MainWindowViewModel : BindableBase
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

        private string _title = "Prism Application";
        /// <summary>
        /// 타이틀
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        /// <summary>
        /// 디자인 타임 생성자
        /// </summary>
        public MainWindowViewModel()
        {
        }
        /// <summary>
        /// 런타임 생성자
        /// </summary>
        public MainWindowViewModel(IContainerProvider containerProvider, IRegionManager regionManager, IAppContext appContext)
        {
            _containerProvider = containerProvider;
            _regionManager = regionManager;
            AppContext = appContext;

            Init();
        }

        private void Init()
        {
            //첫 시작 화면
            _regionManager.RegisterViewWithRegion("ContentRegion", "Login");
        }

    }
}
