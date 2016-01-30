using System;
using WebAPI_Learning_1.Interfaces;

namespace WebAPI_Learning_1.Data.Users
{
    public class User :IEntity, IHasTouchedProperties
    {
        public User()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedAt { get; }
        public DateTime? ModifiedAt { get; set; }
    }
}