using Microsoft.Extensions.DependencyInjection;
using WiWheeIn.BusinessLogic.Devices;
using WiWheeIn.BusinessLogic.Mouse;
using WiWheeIn.BusinessLogic.User;
using WiWheeIn.Windows.Devices;
using WiWheeIn.Windows.Mouse;
using WiWheeIn.Windows.User;

namespace WiWheeIn.Windows
{
    public static class Bootstrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDevicePathBuilder, DevicePathBuilder>();
            services.AddSingleton<IMouseDeviceCrawler, MouseDeviceCrawler>();
            services.AddSingleton<IMouseWheelInvertedStateService, MouseWheelInvertedStateService>();
            services.AddSingleton<IMouseDeviceViewModelFactory, MouseDeviceViewModelFactory>();
            services.AddSingleton<IUserInfoService, UserInfoService>();

            services.AddTransient<MouseDeviceViewModel>();
            services.AddTransient<MouseDevicesViewModel>();
        }
    }
}
