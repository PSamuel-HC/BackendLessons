using Homework_GenericTypesAndConstraints.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_GenericTypesAndConstraints.Models
{
    internal class Product : IEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string ProductName { get; set; } = string.Empty;
        public double Price { get; set; } = 0.0;

        public Product(){ }

        public Product(Guid? id = null, string? productName = null, double? price = null)
        {
            Id = id ?? Guid.NewGuid();
            ProductName = productName ?? string.Empty;
            Price = 0.0;
        }
    }
}
