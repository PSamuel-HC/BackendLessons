using MyStore.Domain.Emuns;

namespace MyStore.Domain.Model
{
    public class Order
    {
        public int Id { get; set; } // The Primary Key
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string ShippingAddress { get; set; }
    }
}
