namespace App.Domain.UserModel
{
    public class UserInfo
    {
        private UserId userId;
        private UserName userName;
        
        public UserInfo(UserId userId, UserName userName)
        {
            this.userId = userId;
            this.userName = userName;
        }
        
        public UserName ChangeUserName(UserName newUserName)
        {
            this.userName = newUserName;
            return this.userName;
        }
    }

}