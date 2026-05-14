using MyStore.Service.DTOs.OrderDTOs;

namespace MyStore.Service.Orders
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderReadDto>> GetOrdersAsync();
        Task<OrderReadDto?> GetOrderByIdAsync(int id);
        Task<OrderReadDto> CreateOrderAsync(OrderCreateDto dto);
        Task<bool> UpdateOrderAsync(int id, OrderUpdateDto dto);
        Task<bool> DeleteOrderAsync(int id);
    }
}
