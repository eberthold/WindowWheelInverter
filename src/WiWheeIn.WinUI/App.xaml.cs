using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;
using WiWheeIn.BusinessLogic.Devices;
using WiWheeIn.BusinessLogic.Mouse;
using WiWheeIn.Windows;
using WiWheeIn.Windows.Devices;
using WiWheeIn.Windows.Mouse;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WiWheeIn.WinUI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            var services = new ServiceCollection();
            Bootstrapper.ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        public IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();
        }

        private Window m_window;
    }
}
