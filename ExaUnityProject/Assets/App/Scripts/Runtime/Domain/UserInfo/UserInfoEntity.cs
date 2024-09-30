namespace App.Domain.UserInfo
{
    public class UserInfoEntity
    {
        public readonly UserId UserId;
        public readonly UserName UserName;
        
        public static UserInfoEntity CreateNew()
        {
            return new UserInfoEntity(UserId.CreateNew(), UserName.CreateNew());
        }
        
        private UserInfoEntity(UserId userId, UserName userName)
        {
            UserId = userId;
            UserName = userName;
        }
        
        public UserInfoEntity ChangeUserName(string newName)
        {
            var newUserName = UserName.ChangeUserName(newName);
            return new UserInfoEntity(UserId, newUserName);
        }
    }

}