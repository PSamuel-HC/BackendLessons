using AutoMapper;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Model;
using MyStore.Service.DTOs;

namespace MyStore.Service.Products
{
    public class ProductService(IProductRepository repository, IMapper mapper) : IProductService
    {
        public async Task<ProductReadDto> CreateProduct(ProductCreateDto dto)
        {
           Product p = await repository.Create(mapper.Map<Product>(dto));
           return mapper.Map<ProductReadDto>(p);
        }

        public async Task DeleteProduct(int id)
        {
            Product? p = await repository.GetById(id);

            if (p == null) return; //question 

            await repository.Delete(p);
        }

        public async Task<ProductReadDto> GetProduct(int id)
        {
            Product p = await repository.GetById(id);
            if (p == null) { }
            return mapper.Map<ProductReadDto>(p);

        }

        public async Task<IEnumerable<ProductReadDto>> GetProductsAsync()
        {
            IEnumerable<Product> products = await repository.GetAllAsync();

            return mapper.Map<IEnumerable<ProductReadDto>>(products);
        }

        public async Task UpdateProduct(int id, ProductUpdateDto dto)
        {
            Product? p = await repository.GetById(id);

            if (p == null) return;

            Product product2 = mapper.Map(dto, p);
            product2.Id = id;

            await repository.Update(product2);
        }
    }
}
