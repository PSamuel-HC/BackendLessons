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

        public Task<Customer> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync()
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
