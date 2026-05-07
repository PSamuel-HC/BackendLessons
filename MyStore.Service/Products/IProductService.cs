using MyStore.Service.DTOs;

namespace MyStore.Service.Products
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductReadDto>> GetProductsAsync();
    }
}
