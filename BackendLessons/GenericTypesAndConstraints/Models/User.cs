using System;
using System.Collections.Generic;
using System.Text;

using GenericTypesAndConstraints.Interfaces;

namespace GenericTypesAndConstraints.Models
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        // Parameterless constructor
        public User()
        {
            Id = Guid.NewGuid();
            Username = string.Empty;
        }

        // Custom constructor
        public User(Guid? id = null, string? username = null)
        {
            Id = id ?? Guid.NewGuid();
            Username = username ?? string.Empty;
        }
    }
}
