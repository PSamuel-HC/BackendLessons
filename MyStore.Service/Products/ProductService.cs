using AutoMapper;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Model;
using MyStore.Service.DTOs;

namespace MyStore.Service.Products
{
    public class ProductService(IProductRepository repository, IMapper mapper) : IProductService
    {
        public async Task<IEnumerable<ProductReadDto>> GetProductsAsync()
        {
            IEnumerable<Product> products = await repository.GetAllAsync();

            return mapper.Map<IEnumerable<ProductReadDto>>(products);
        }
    }
}
