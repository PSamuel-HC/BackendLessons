using System;
using System.Collections.Generic;
using System.Text;

using GenericTypesAndConstraints.Interfaces;

namespace GenericTypesAndConstraints.Models
{
    public class Product : IEntity
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        // Parameterless constructor
        public Product()
        {
            Id = Guid.NewGuid();
            ProductName = string.Empty;
            Price = 0.0;
        }

        // Custom constructor
        public Product(Guid? id = null, string? productName = null, double? price = null)
        {
            Id = id ?? Guid.NewGuid();
            ProductName = productName ?? string.Empty;
            Price = price ?? 0.0;
        }
    }
}
