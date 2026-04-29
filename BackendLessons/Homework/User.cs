using System;
using System.Collections.Generic;
using System.Text;

namespace JalaUniversity.BackendLessons
{
    public class User : IEntity
    {
        public Guid Id { get; private set; }
        public string Username { get; set; }

 
        public User()
        {
            Id = Guid.NewGuid();
            Username = string.Empty;
        }

        public User(Guid? id, string? username = null)
        {
            Id = id ?? Guid.NewGuid();
            Username = username ?? string.Empty; 
        }
    }
}
