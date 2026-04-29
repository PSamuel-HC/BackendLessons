using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkGenericTypes
{
    internal class User : IEntity
    {
        public string Name {  get; set; }
        public Guid Id { get; set ; }

        public User(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public User()
        {
            Id = Guid.NewGuid();
        }


    }
}
