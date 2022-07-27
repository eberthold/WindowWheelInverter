using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace WiWheeIn.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        [STAThread]
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            Bootstrapper.ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var app = new App(); 
            var window = new MainWindow();
            app.Run(window);
        }

        public static IServiceProvider ServiceProvider { get; private set; } = null!;
    }
}
