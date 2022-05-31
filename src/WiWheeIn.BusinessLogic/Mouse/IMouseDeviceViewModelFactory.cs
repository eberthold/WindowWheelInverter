using WiWheeIn.BusinessLogic.Devices;

namespace WiWheeIn.BusinessLogic.Mouse
{
    public interface IMouseDeviceViewModelFactory
    {
        MouseDeviceViewModel Create(DeviceInfo deviceInfo);
    }
}
