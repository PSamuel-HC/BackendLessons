}using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkGenericTypes
{
    internal class Product : IEntity
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public Product()
        {

        }

        public Product(Guid id, string name, double price)
        {
            Id = id;
            ProductName= name;
            Price = price;
        }

    }
}
