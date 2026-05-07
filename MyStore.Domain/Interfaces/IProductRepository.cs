using MyStore.Domain.Model;

namespace MyStore.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
