using Microsoft.Win32;
using WiWheeIn.BusinessLogic.Devices;
using WiWheeIn.BusinessLogic.Mouse;

namespace WiWheeIn.Windows.Mouse;

public class MouseWheelInvertedStateService : IMouseWheelInvertedStateService
{
    private const string InvertedWheelRegistryFlagName = "FlipFlopWheel";

    private readonly IDevicePathBuilder _devicePathBuilder;

    public MouseWheelInvertedStateService(IDevicePathBuilder devicePathBuilder)
    {
        _devicePathBuilder = devicePathBuilder;
    }

    public Task<bool> GetIsInvertedStateAsync(DeviceInfo deviceInfo)
    {
        var path = _devicePathBuilder.GetDevicePath(deviceInfo);
        var result = Registry.GetValue(path, InvertedWheelRegistryFlagName, false) as int?;

        switch (result)
        {
            case 1:
                return Task.FromResult(true);

            default:
                return Task.FromResult(false);
        }
    }

    public Task SetIsInvertedStateAsync(DeviceInfo deviceInfo, bool value)
    {
        var path = _devicePathBuilder.GetDevicePath(deviceInfo);

        var registryValue = value ? 1 : 0;
        Registry.SetValue(path, InvertedWheelRegistryFlagName, registryValue, RegistryValueKind.DWord);

        return Task.CompletedTask;
    }
}
