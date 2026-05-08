using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Model;

namespace MyStore.Infrastructure.Repositories
{
    public class CustomerRepository(MyStoreDbContext context) : ICustomerRepository
    {
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetOneAsync(int id)
        {
            return await context.Customers.FindAsync(id);
        }

        public async Task CreateAsync(Customer customer)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();

        }

        public Task UpdateAsync()
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
