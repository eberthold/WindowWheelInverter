using Microsoft.Toolkit.Mvvm.ComponentModel;
using WiWheeIn.BusinessLogic.User;

namespace WiWheeIn.BusinessLogic
{
    public class ApplicationStateViewModel : ObservableObject
    {
        private readonly IUserInfoService _userInfoService;
        private bool _isUserAdmin;

        public ApplicationStateViewModel(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public bool IsUserAdmin
        {
            get => _isUserAdmin;
            set => SetProperty(ref _isUserAdmin, value);
        }

        public async Task LoadDataAsync()
        {
            IsUserAdmin = await _userInfoService.CheckUserIsAdminAsync().ConfigureAwait(false);
        }
    }
}
