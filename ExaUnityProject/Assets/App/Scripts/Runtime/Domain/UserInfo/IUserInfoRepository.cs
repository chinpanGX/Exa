namespace App.Domain.UserInfo
{
    public interface IUserInfoRepository
    {
        UserInfoEntity GetUserInfo();
        void Save(UserInfoEntity userInfoEntity);
        void Load();
    }
}