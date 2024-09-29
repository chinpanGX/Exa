namespace App.Domain.UserModel
{
    public class UserInfo
    {
        private UserId UserId;
        private UserName UserName;
        
        public UserInfo(UserId userId, UserName userName)
        {
            UserId = userId;
            UserName = userName;
        }
        
        public UserName ChangeUserName(UserName userName)
        {
            UserName = userName;
            return UserName;
        }
    }

}