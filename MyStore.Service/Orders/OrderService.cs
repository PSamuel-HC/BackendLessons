using AutoMapper;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Model;
using MyStore.Service.DTOs;

namespace MyStore.Service.Orders
{
    public class OrderService(IOrderRepository repository, IMapper mapper) : IOrderService
    {
        public async Task<IEnumerable<OrderReadDto>> GetOrdersAsync()
        {
            var orders = await repository.GetAllAsync();
            return mapper.Map<IEnumerable<OrderReadDto>>(orders);
        }

        public async Task<OrderReadDto?> GetOrderByIdAsync(int id)
        {
            var order = await repository.GetByIdAsync(id);
            return order is null ? null : mapper.Map<OrderReadDto>(order);
        }

        public async Task<OrderReadDto> CreateOrderAsync(OrderCreateDto dto)
        {
            var order = mapper.Map<Order>(dto);
            await repository.AddAsync(order);
            await repository.SaveChangesAsync();
            return mapper.Map<OrderReadDto>(order);
        }

        public async Task<bool> UpdateOrderAsync(int id, OrderUpdateDto dto)
        {
            var order = await repository.GetByIdAsync(id);
            if (order is null) return false;

            // Partial update con ?? — solo actualiza si el DTO trae valor
            order.TotalAmount = dto.TotalAmount ?? order.TotalAmount;
            order.CustomerName = dto.CustomerName ?? order.CustomerName;
            order.ShippingAddress = dto.ShippingAddress ?? order.ShippingAddress;
            order.Status = dto.Status ?? order.Status;

            await repository.UpdateAsync(order);
            await repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await repository.GetByIdAsync(id);
            if (order is null) return false;

            await repository.DeleteAsync(order);
            await repository.SaveChangesAsync();
            return true;
        }
    }
}