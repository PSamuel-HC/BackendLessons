using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Model;

namespace MyStore.Infrastructure.Repositories
{
    public class OrderRepository(MyStoreDbContext context) : IOrderRepository
    {
        public async Task<IEnumerable<Order>> GetAllAsync()
            => await context.Orders.ToListAsync();

        public async Task<Order?> GetByIdAsync(int id)
            => await context.Orders.FindAsync(id);

        public async Task AddAsync(Order order)
            => await context.Orders.AddAsync(order);

        public Task UpdateAsync(Order order)
        {
            context.Orders.Update(order);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Order order)
        {
            context.Orders.Remove(order);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
            => await context.SaveChangesAsync();
    }
}