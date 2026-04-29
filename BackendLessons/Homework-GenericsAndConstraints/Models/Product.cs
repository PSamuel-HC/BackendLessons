using JalaUniversity.Homework_GenericsAndConstraints.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace JalaUniversity.Homework_GenericsAndConstraints.Models
{
    internal class Product : IEntity
    {
        /*
         The ID and price have their default values. 
         */
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string? ProductName { get; set; } 
        /*Null values ​​are being allowed in 
         the product name due to the nature of the problem.*/
        public double Price { get; set; } = 0;

        public Product(){}

        public Product(Guid id, string? productName, double price = 0) {
            Id = id;
            ProductName = productName;
            Price = price;
        }





    }
}
