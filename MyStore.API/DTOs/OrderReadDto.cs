using MyStore.Domain.Emuns;

namespace MyStore.API.DTOs
{
    public class OrderReadDto
    { 
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime EstimatedDelivery { get; set; } = DateTime.UtcNow.AddDays(7);
    }
}
