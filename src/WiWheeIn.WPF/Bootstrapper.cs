using Microsoft.Extensions.DependencyInjection;
using WiWheeIn.BusinessLogic.Framework;
using WiWheeIn.WPF.Framework;
using Shared = WiWheeIn.Windows;

namespace WiWheeIn.WPF
{
    internal static class Bootstrapper
    {
        internal static void ConfigureServices(IServiceCollection services)
        {
            Shared.Bootstrapper.ConfigureServices(services);
            services.AddSingleton<IMainThreadDispatcher, MainThreadDispatcher>();
        }
    }
}
