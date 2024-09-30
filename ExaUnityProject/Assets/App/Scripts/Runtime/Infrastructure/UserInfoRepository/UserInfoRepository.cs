using App.Domain.UserInfo;
using UnityEngine;

namespace App.Infrastructure.UserInfoRepository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private UserInfoEntity userInfoEntity;
        public UserInfoEntity GetUserInfo()
        {
            return userInfoEntity;
        }
        
        public void Save(UserInfoEntity userInfoEntity)
        {
            PlayerPrefs.SetString("UserId", userInfoEntity.UserId.Id);
            this.userInfoEntity = userInfoEntity;
        }
        
        public void Load()
        {
            var userId = PlayerPrefs.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                var newUserInfo = UserInfoEntity.CreateNew();
                Save(newUserInfo);
            }
        }
    }
}
