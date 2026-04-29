using Homework_GenericTypesAndConstraints.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_GenericTypesAndConstraints.Models
{
    internal class User : IEntity
    {

        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Username { get; set; } = string.Empty;

        public User() { }

        public User(Guid? id = null, string? username = null)
        {
            Id = id ?? Guid.NewGuid();
            Username = username ?? string.Empty;
        }

    }
}
