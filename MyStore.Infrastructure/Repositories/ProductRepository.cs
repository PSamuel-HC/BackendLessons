using MyStore.Domain.Interfaces;
using MyStore.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace MyStore.Infrastructure.Repositories
{
    public class ProductRepository(MyStoreDbContext context) : IProductRepository
    {
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await context.Products.ToListAsync();
        }
    }
}
