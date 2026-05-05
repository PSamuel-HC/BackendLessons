using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Domain.Model
{
    public class Product
    {
        public int Id { get; set; } // The Primary Key
        public string Description { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
