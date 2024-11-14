using Microsoft.Extensions.DependencyInjection;
using MVVMTemplate.Helpers;
using MVVMTemplate.Logging;
using MVVMTemplate.ViewModels;
using System.Windows;

namespace MVVMTemplate
{
    /// <summary>
    /// Provides application-level functionality and configuration for dependency injection.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Gets the global <see cref="IServiceProvider"/> instance used for dependency injection.
        /// </summary>
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// Initializes the application and configures services for dependency injection.
        /// </summary>
        /// <param name="e">The startup event arguments.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        /// <summary>
        /// Configures services and registers dependencies in the service collection.
        /// </summary>
        /// <param name="serviceCollection">The service collection to configure.</param>
        private static void ConfigureServices(ServiceCollection serviceCollection)
        {
            // Register the ViewModelLocator as a singleton to provide easy ViewModel access throughout the application.
            serviceCollection.AddSingleton<ViewModelLocator>();

            // Register the MainWindow as a singleton to ensure a single instance in the application.
            serviceCollection.AddSingleton<MainWindow>();

            // Register MainWindowViewModel with a transient lifetime, creating a new instance each time it is requested.
            serviceCollection.AddTransient<MainWindowViewModel>();

            // Register the logging service to provide logging functionality throughout the application.
            serviceCollection.AddTransient<ILoggingService, LoggingService>();
        }
    }

}
