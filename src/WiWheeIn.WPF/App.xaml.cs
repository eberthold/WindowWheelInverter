using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WiWheeIn.BusinessLogic.Devices;
using WiWheeIn.BusinessLogic.Mouse;
using WiWheeIn.Windows.Devices;
using WiWheeIn.Windows.Mouse;

namespace WiWheeIn.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddSingleton<IDevicePathBuilder, DevicePathBuilder>();
            services.AddSingleton<IMouseDeviceCrawler, MouseDeviceCrawler>();
            services.AddSingleton<IMouseWheelInvertedStateService, MouseWheelInvertedStateService>();
            services.AddSingleton<IMouseDeviceViewModelFactory, MouseDeviceViewModelFactory>();

            services.AddTransient<MouseDeviceViewModel>();
            services.AddTransient<MouseDevicesViewModel>();

            ServiceProvider = services.BuildServiceProvider();

            var window = new MainWindow();
            var app = new App();
            app.Run(window);
        }

        public static IServiceProvider ServiceProvider { get; private set; } = null!;
    }
}
