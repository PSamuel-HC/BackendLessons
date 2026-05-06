using MyStore.Domain.Emuns;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Domain.Model
{
    public class Order
    {
        public int Id { get; set; } // The Primary Key
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public string ShippingAddress { get; set; }
    }
}
