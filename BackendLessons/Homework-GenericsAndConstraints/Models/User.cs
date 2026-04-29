using JalaUniversity.Homework_GenericsAndConstraints.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JalaUniversity.Homework_GenericsAndConstraints.Models
{
    internal class User : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Username { get; set; } //Null values ​​are being allowed in the name, because default instantiations may exist.

        public User() {}
        public User(Guid id, string? userName)
        {
            Id = id;
            Username = userName;
        }


    }
}
