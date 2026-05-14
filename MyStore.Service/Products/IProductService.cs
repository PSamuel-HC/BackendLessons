using MyStore.Service.DTOs.ProductDTOs;

namespace MyStore.Service.Products
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductReadDto>> GetProductsAsync();

        public Task<ProductReadDto> GetProduct(int id);

        public Task<ProductReadDto> CreateProduct(ProductCreateDto dto);
        public Task UpdateProduct(int id, ProductUpdateDto dto);

        public Task DeleteProduct(int id);
    }
}
