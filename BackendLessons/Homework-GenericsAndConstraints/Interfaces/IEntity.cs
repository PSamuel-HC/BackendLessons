using System;
using System.Collections.Generic;
using System.Text;

namespace JalaUniversity.Homework_GenericsAndConstraints.Interfaces
{
    internal interface IEntity
    {
        public Guid Id { get; } 
        /*The "set" is not included in the interface
         * so that it can be customized in the implementations.*/

    }
}
