using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.Immutable;

namespace WiWheeIn.BusinessLogic.Mouse;

public class MouseDevicesViewModel : ObservableObject
{
    private bool _isLoading;
    private IReadOnlyCollection<MouseDeviceViewModel> _mouseDevices = ImmutableList<MouseDeviceViewModel>.Empty;
    private readonly IMouseDeviceCrawler _deviceCrawler;
    private readonly IMouseDeviceViewModelFactory _mouseDeviceViewModelFactory;

    public MouseDevicesViewModel(
        IMouseDeviceCrawler deviceCrawler,
        IMouseDeviceViewModelFactory mouseDeviceViewModelFactory)
    {
        _deviceCrawler = deviceCrawler;
        _mouseDeviceViewModelFactory = mouseDeviceViewModelFactory;
    }

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
}
