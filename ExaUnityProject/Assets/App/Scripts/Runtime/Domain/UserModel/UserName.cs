using System;

namespace App.Domain.UserModel
{
    public readonly struct UserName
    {
        public string Name { get; }
        
        public UserName(string name)
        {
            if(string.IsNullOrEmpty(name)) 
                throw new ArgumentException("Name cannot be null or empty", nameof(name));
            Name = name;
        }
    }
}