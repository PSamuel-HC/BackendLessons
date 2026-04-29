using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.GoldenRecord.Models
{
    public class Product : IEntity
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public double Price { get; set; } // default value is 0 without needing to specify

        public Product() {
            Id = Guid.NewGuid(); // If this is not generated, it will generate as '00000000-0000-0000-0000-000000000000' by default
        }

        public Product(Guid id, string productName, double price)
        {
            Id = id;
            ProductName = productName;
            Price = price;
        }
    }
}
