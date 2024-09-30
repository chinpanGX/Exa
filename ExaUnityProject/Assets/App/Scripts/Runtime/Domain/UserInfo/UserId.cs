using System;

namespace App.Domain.UserInfo
{
    public readonly struct UserId
    {
        public string Id { get; }

        public static UserId CreateNew()
        {
            return new UserId(Guid.NewGuid().ToString());
        }

        private UserId(string id)
        {
            if(string.IsNullOrEmpty(id))
                throw new ArgumentException("Id cannot be null or empty", nameof(id));
            Id = id;
        }
    }
}