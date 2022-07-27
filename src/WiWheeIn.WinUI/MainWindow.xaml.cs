using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using WiWheeIn.BusinessLogic;
using WiWheeIn.BusinessLogic.Mouse;
using WiWheeIn.Windows.User;

namespace WiWheeIn.WinUI;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();

        var devicesViewModel = ((App)Application.Current).ServiceProvider.GetRequiredService<MouseOverviewViewModel>();
        PART_Page.DataContext = devicesViewModel;
        _ = devicesViewModel.LoadDataAsync();

        var applicationStateViewModel = new ApplicationStateViewModel(new UserInfoService());
        PART_Root.DataContext = applicationStateViewModel;
        _ = applicationStateViewModel.LoadDataAsync().ConfigureAwait(false);
    }
}
