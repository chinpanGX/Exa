using App.Domain.UserModel;
using UnityEngine;

namespace App.Application.UserModelService
{
    public class UserModelService
    {
        private IUerInfoRepository repository;
        
        public UserModelService(IUerInfoRepository repository)
        {
            this.repository = repository;
        }
    }
}
