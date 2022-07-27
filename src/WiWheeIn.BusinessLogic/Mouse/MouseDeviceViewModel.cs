using Microsoft.Toolkit.Mvvm.ComponentModel;
using WiWheeIn.BusinessLogic.Devices;
using WiWheeIn.BusinessLogic.User;

namespace WiWheeIn.BusinessLogic.Mouse;

public class MouseDeviceViewModel : ObservableObject
{
    private readonly DeviceInfo _deviceInfo;
    private readonly IDevicePathBuilder _devicePathBuilder;
    private readonly IMouseWheelInvertedStateService _mouseInvertedStateService;
    private readonly IUserInfoService _userInfoService;
    private bool _canSetState;
    private bool _isInverted;
    private string _devicePath = string.Empty;

    public MouseDeviceViewModel(
        DeviceInfo deviceInfo,
        IDevicePathBuilder devicePathBuilder,
        IMouseWheelInvertedStateService mouseInvertedStateService,
        IUserInfoService userInfoService)
    {
        _deviceInfo = deviceInfo;
        _devicePathBuilder = devicePathBuilder;
        _mouseInvertedStateService = mouseInvertedStateService;
        _userInfoService = userInfoService;
    }

    public string Manufacturer => _deviceInfo.Manufacturer;

    public string Name => _deviceInfo.Name;

    public string DevicePath
    {
        get => _devicePath;
        private set => SetProperty(ref _devicePath, value);
    }

    public bool IsInverted
    {
        get => _isInverted;
        set
        {
            if (!SetProperty(ref _isInverted, value))
            {
                return;
            }

            _ = UpdateIsInvertedStateAsync(value);
        }
    }

    public bool CanSetState
    {
        get => _canSetState;
        set => SetProperty(ref _canSetState, value);
    }

    public IDictionary<string, string> AllInfos => _deviceInfo.AllInfos;

    public async Task LoadDataAsync()
    {
        DevicePath = _devicePathBuilder.GetDevicePath(_deviceInfo);
        _isInverted = await _mouseInvertedStateService.GetIsInvertedStateAsync(_deviceInfo).ConfigureAwait(false);
        _canSetState = await _userInfoService.CheckUserIsAdminAsync().ConfigureAwait(false);
        OnPropertyChanged(nameof(IsInverted));
    }

    private async Task UpdateIsInvertedStateAsync(bool value)
    {
        await _mouseInvertedStateService.SetIsInvertedStateAsync(_deviceInfo, value).ConfigureAwait(false);
        _isInverted = await _mouseInvertedStateService.GetIsInvertedStateAsync(_deviceInfo).ConfigureAwait(false);
        OnPropertyChanged(nameof(IsInverted));
    }

    public override string ToString()
    {
        return $"{Manufacturer} - {Name}";
    }
}
