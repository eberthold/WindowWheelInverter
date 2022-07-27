using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WiWheeIn.BusinessLogic;
using WiWheeIn.BusinessLogic.Mouse;
using WiWheeIn.Windows.User;

namespace WiWheeIn.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var vm = App.ServiceProvider.GetRequiredService<MouseOverviewViewModel>();
            PART_Page.DataContext = vm;
            _ = vm.LoadDataAsync().ConfigureAwait(false);

            var pageVm = new ApplicationStateViewModel(new UserInfoService());
            DataContext = pageVm;
            _ = pageVm.LoadDataAsync().ConfigureAwait(false);
        }
    }
}
