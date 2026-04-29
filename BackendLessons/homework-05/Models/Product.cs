using homework_05.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace homework_05.Models
{
    internal class Product : IEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public Product()
        {
            Id = 0;
            ProductName = "";
            Price = 0.00m;
        }

        public Product(int id, string productName, decimal price)
        {
            Id = id;
            ProductName = productName;
            Price = price;
        }

    }
}
