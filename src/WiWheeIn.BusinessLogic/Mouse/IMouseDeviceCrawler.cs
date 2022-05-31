using WiWheeIn.BusinessLogic.Devices;

namespace WiWheeIn.BusinessLogic.Mouse;

public interface IMouseDeviceCrawler
{
    Task<List<DeviceInfo>> GetMouseDevicesAsync();
}
