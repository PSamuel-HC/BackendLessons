using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.GoldenRecord.Models
{
    public class User : IEntity
    {
        public Guid Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public User() {
            Id = Guid.NewGuid(); // If this is not generated, it will generate as '00000000-0000-0000-0000-000000000000' by default
        }

        public User(Guid id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}
