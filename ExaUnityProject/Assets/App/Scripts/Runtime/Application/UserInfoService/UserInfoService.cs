using App.Domain.UserInfo;
using UnityEngine;

namespace App.Application.UserInfoService
{
    public class UserInfoService
    {
        private IUserInfoRepository repository;
        
        public UserInfoService(IUserInfoRepository repository)
        {
            this.repository = repository;
        }
    }
}
