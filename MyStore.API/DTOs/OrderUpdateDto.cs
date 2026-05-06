using MyStore.Domain.Emuns;

namespace MyStore.API.DTOs
{
    public class OrderUpdateDto
    { 
        public string? CustomerName { get; set; }
        public decimal? TotalAmount { get; set; }
        public OrderStatus? Status { get; set; }
        public string? ShippingAddress { get; set; }
    }
}
