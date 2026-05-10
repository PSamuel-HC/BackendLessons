using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Model;

namespace MyStore.Infrastructure.Repositories
{
    public class ProductRepository(MyStoreDbContext context) : IProductRepository
    {
        public async Task<Product> Create(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return  product;
        }

        public async Task Delete(Product product)
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task Update(Product product)
        {
            context.Products.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
