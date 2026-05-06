using MyStore.Domain.Emuns;

namespace MyStore.API.DTOs
{
    public class OrderCreateDto
    {
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public string ShippingAddress { get; set; }
    }
}
