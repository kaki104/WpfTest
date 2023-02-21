using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using ViewModelReuseSample.ViewModels;

namespace ViewModelReuseSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
            InitializeComponent();
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public static new App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            ServiceCollection services = new();

            //ViewModel 싱글 톤 등록
            _ = services.AddSingleton(typeof(MainWindowViewModel));

            return services.BuildServiceProvider();
        }
    }
}
