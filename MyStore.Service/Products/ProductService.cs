using AutoMapper;
using FluentValidation;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Model;
using MyStore.Service.DTOs;
using MyStore.Service.Validators;

namespace MyStore.Service.Products
{
    public class ProductService(
        IProductRepository repository,
        IMapper mapper,
        ProductCreateDtoValidator validatorCreate,
        ProductUpdateDtoValidator validatorUpdate
        ) : IProductService
    {
        public async Task<ProductReadDto> CreateProduct(ProductCreateDto dto)
        {
            validatorCreate.ValidateAndThrow(dto);
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
            validatorUpdate.ValidateAndThrow(dto);
            Product? p = await repository.GetById(id);

            if (p == null) return;

            await repository.Update(mapper.Map(dto, p));
        }
    }
}
