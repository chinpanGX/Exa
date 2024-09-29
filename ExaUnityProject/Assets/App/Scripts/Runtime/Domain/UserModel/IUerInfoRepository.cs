namespace App.Domain.UserModel
{
    public interface IUerInfoRepository
    {
        UserInfo GetUserInfo(UserId userId);
        void SaveUserInfo(UserInfo userInfo);
    }
}