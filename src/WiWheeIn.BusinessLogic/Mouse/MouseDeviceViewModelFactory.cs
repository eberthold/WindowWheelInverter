using WiWheeIn.BusinessLogic.Devices;

namespace WiWheeIn.BusinessLogic.Mouse
{
    public class MouseDeviceViewModelFactory : IMouseDeviceViewModelFactory
    {
        private readonly IDevicePathBuilder _devicePathBuilder;
        private readonly IMouseWheelInvertedStateService _mouseWheelInvertedStateService;

        public MouseDeviceViewModelFactory(
            IDevicePathBuilder devicePathBuilder,
            IMouseWheelInvertedStateService mouseWheelInvertedStateService)
        {
            _devicePathBuilder = devicePathBuilder;
            _mouseWheelInvertedStateService = mouseWheelInvertedStateService;
        }

        public MouseDeviceViewModel Create(DeviceInfo deviceInfo)
        {
            return new MouseDeviceViewModel(
                deviceInfo,
                _devicePathBuilder,
                _mouseWheelInvertedStateService);
        }
    }
}
