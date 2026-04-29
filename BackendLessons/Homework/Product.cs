using System;
using System.Collections.Generic;
using System.Text;

namespace JalaUniversity.BackendLessons
{
    public class Product : IEntity
    {
        public Guid Id { get; private set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public Product()
        {
            Id = Guid.NewGuid();
            ProductName = String.Empty;
            Price = 0.0;
        }

        public Product(Guid? id, string? productName = null, double? price = null)
        {
            Id = id ?? Guid.NewGuid(); 
            ProductName = productName ?? string.Empty;
            Price = price ?? 0.0;
        }

    }
}
