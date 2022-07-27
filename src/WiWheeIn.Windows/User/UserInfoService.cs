using System.Security.Principal;
using WiWheeIn.BusinessLogic.User;

namespace WiWheeIn.Windows.User
{
    public class UserInfoService : IUserInfoService
    {
        public Task<bool> CheckUserIsAdminAsync()
        {
            using var identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            var isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            return Task.FromResult(isAdmin);
        }
    }
}
