using WiWheeIn.BusinessLogic.Devices;

namespace WiWheeIn.Windows.Devices;

public class DevicePathBuilder : IDevicePathBuilder
{
    public string GetDevicePath(DeviceInfo deviceInfo)
    {
        return $"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Enum\\{deviceInfo.DeviceId}\\Device Parameters";
    }
}
