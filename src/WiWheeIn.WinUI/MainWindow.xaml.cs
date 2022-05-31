using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using WiWheeIn.BusinessLogic.Mouse;

namespace WiWheeIn.WinUI;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();

        var vm = (App.Current as App).ServiceProvider.GetService<MouseDevicesViewModel>();
        PART_Page.DataContext = vm;
        _ = vm.LoadDataAsync();
    }
}
