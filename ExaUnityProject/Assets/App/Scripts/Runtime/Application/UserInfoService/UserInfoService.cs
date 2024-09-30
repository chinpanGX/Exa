using App.Domain.UserInfo;

namespace App.Application.UserInfoService
{
    public class UserInfoService
    {
        private readonly IUserInfoRepository repository;
        
        public UserInfoService(IUserInfoRepository repository)
        {
            this.repository = repository;
        }
        
        public void UpdateUserName(string newName)
        {
            var userInfoEntity = repository.GetUserInfo();
            var newUserInfoEntity = userInfoEntity.ChangeUserName(newName);
            repository.Save(newUserInfoEntity);
        }
        
        public string GetUserName()
        {
            var entity = repository.GetUserInfo();
            return entity.UserName.Name;
        }
    }
}
