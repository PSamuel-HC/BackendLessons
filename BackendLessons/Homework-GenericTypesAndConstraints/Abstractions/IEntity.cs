using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_GenericTypesAndConstraints.Abstractions
{
    internal interface IEntity
    {
        
        // We cannot define a private set inside the Interface
        // We do define the private set inside User and Product
        public Guid Id { get; }
    }
}
