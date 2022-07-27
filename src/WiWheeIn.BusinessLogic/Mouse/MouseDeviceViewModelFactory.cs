using WiWheeIn.BusinessLogic.Devices;
using WiWheeIn.BusinessLogic.User;

namespace WiWheeIn.BusinessLogic.Mouse
{
    public class MouseDeviceViewModelFactory : IMouseDeviceViewModelFactory
    {
        private readonly IDevicePathBuilder _devicePathBuilder;
        private readonly IMouseWheelInvertedStateService _mouseWheelInvertedStateService;
        private readonly IUserInfoService _userInfoService;

        public MouseDeviceViewModelFactory(
            IDevicePathBuilder devicePathBuilder,
            IMouseWheelInvertedStateService mouseWheelInvertedStateService,
            IUserInfoService userInfoService)
        {
            _devicePathBuilder = devicePathBuilder;
            _mouseWheelInvertedStateService = mouseWheelInvertedStateService;
            _userInfoService = userInfoService;
        }

        public MouseDeviceViewModel Create(DeviceInfo deviceInfo)
        {
            return new MouseDeviceViewModel(
                deviceInfo,
                _devicePathBuilder,
                _mouseWheelInvertedStateService,
                _userInfoService);
        }
    }
}
