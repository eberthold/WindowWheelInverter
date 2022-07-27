using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Immutable;
using WiWheeIn.BusinessLogic.Framework;

namespace WiWheeIn.BusinessLogic.Mouse;

public class MouseOverviewViewModel : ObservableObject
{
    private bool _isLoading;
    private IReadOnlyCollection<MouseDeviceViewModel> _mouseDevices = ImmutableList<MouseDeviceViewModel>.Empty;
    private readonly IMouseDeviceCrawler _deviceCrawler;
    private readonly IMouseDeviceViewModelFactory _mouseDeviceViewModelFactory;
    private readonly IMainThreadDispatcher _mainThreadDispatcher;

    public MouseOverviewViewModel(
        IMouseDeviceCrawler deviceCrawler,
        IMouseDeviceViewModelFactory mouseDeviceViewModelFactory,
        IMainThreadDispatcher mainThreadDispatcher)
    {
        _deviceCrawler = deviceCrawler;
        _mouseDeviceViewModelFactory = mouseDeviceViewModelFactory;
        _mainThreadDispatcher = mainThreadDispatcher;
        ReloadCommand = new AsyncRelayCommand(ReloadAsync, CheckCanReload);
    }

    public AsyncRelayCommand ReloadCommand { get; }

    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            if (!SetProperty(ref _isLoading, value))
            {
                return;
            }

            OnPropertyChanged(nameof(IsEnabled));
            RefreshCommands();
        }
    }

    public bool IsEnabled => !IsLoading;

    public IReadOnlyCollection<MouseDeviceViewModel> MouseDevices
    {
        get => _mouseDevices;
        set => SetProperty(ref _mouseDevices, value);
    }

    public async Task LoadDataAsync()
    {
        try
        {
            IsLoading = true;

            var devices = await _deviceCrawler.GetMouseDevicesAsync();
            MouseDevices = devices.Select(x => _mouseDeviceViewModelFactory.Create(x)).ToList();
            await Task.WhenAll(MouseDevices.Select(mouse => mouse.LoadDataAsync()));
        }
        finally
        {
            IsLoading = false;
        }
    }

    private Task ReloadAsync()
    {
        return LoadDataAsync();
    }

    private bool CheckCanReload()
    {
        return !IsLoading;
    }

    private void RefreshCommands()
    {
        _mainThreadDispatcher.InvokeOnMainThread(() =>
        {
            ReloadCommand.NotifyCanExecuteChanged();
        });
    }
}
