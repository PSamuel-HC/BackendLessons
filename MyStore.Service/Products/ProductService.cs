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

            if (p == null) { } //question 

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

            if (p == null) { }

            p.Name = dto.Name;
            p.SKU = dto.SKU;
            p.Price = dto.Price;
            p.Manufacturer = dto.Manufacturer;
            p.WarrantyMonths = dto.WarrantyMonths;
            p.Description = dto.Description;

            //  Product p2 = mapper.Map<Product>(p,dto);
            //  p2.Id = id;

            await repository.Update(p);
        }
    }
}
