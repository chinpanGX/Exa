using App.Domain.UserInfo;
using UnityEngine;

namespace App.Infrastructure.UserInfoRepository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        public UserInfoEntity GetUserInfo(UserId userId)
        {
            throw new System.NotImplementedException();
        }
        
        public void Save(UserInfoEntity userInfoEntity)
        {
            PlayerPrefs.SetString("UserId", userInfoEntity.UserId.Id);
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
