﻿using PackUriSample.Module;
using PackUriSample.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace PackUriSample
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
            containerRegistry.RegisterForNavigation<CakeView>();
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<PackUriSampleModule>();
        }
    }
}
