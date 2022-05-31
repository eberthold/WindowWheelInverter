using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WiWheeIn.BusinessLogic.Mouse;

namespace WiWheeIn.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var vm = App.ServiceProvider.GetService<MouseDevicesViewModel>();
            PART_Page.DataContext = vm;
            _ = vm.LoadDataAsync();
        }
    }
}
