using System;

namespace App.Domain.UserModel
{
    public readonly struct UserId
    {
        public string Id { get; }

        public UserId(string id)
        {
            if(string.IsNullOrEmpty(id))
                throw new ArgumentException("Id cannot be null or empty", nameof(id));
            Id = id;
        }
    }
}