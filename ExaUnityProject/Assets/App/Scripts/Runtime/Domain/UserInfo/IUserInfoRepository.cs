namespace App.Domain.UserInfo
{
    public interface IUserInfoRepository
    {
        UserInfoEntity GetUserInfo(UserId userId);
        void Save(UserInfoEntity userInfoEntity);
        void Load();
    }
}