using MyStore.Service.DTOs;

namespace MyStore.Service.Products
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductReadDto>> GetProductsAsync();

        public Task<ProductReadDto> CreateProductAsync(ProductCreateDto product);
    }
}
