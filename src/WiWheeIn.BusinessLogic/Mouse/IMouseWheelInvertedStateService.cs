using WiWheeIn.BusinessLogic.Devices;

namespace WiWheeIn.BusinessLogic.Mouse
{
    public interface IMouseWheelInvertedStateService
    {
        Task<bool> GetIsInvertedStateAsync(DeviceInfo deviceInfo);

        Task SetIsInvertedStateAsync(DeviceInfo deviceInfo, bool value);
    }
}