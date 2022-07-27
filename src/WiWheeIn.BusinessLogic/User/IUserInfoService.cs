namespace WiWheeIn.BusinessLogic.User
{
    public interface IUserInfoService
    {
        Task<bool> CheckUserIsAdminAsync();
    }
}
