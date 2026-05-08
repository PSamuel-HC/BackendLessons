using MyStore.Domain.Model;

namespace MyStore.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetById(int id);
        Task<Product> Create(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}
