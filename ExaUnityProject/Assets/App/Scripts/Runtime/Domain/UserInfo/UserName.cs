using System;

namespace App.Domain.UserInfo
{
    public readonly struct UserName
    {
        public readonly string Name;
        
        public static UserName CreateNew()
        {
            return new UserName("DefaultUserName");
        }
        
        private UserName(string name)
        {
            if(string.IsNullOrEmpty(name)) 
                throw new ArgumentException("Name cannot be null or empty", nameof(name));
            Name = name;
        }

        public UserName ChangeUserName(string newName)
        {
            return new UserName(newName);
        }
    }
}