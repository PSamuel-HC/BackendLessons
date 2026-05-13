using AutoMapper;
using FluentValidation;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Model;
using MyStore.Service.DTOs;
using MyStore.Service.Validators.CustomerDtoValidators;

namespace MyStore.Service.Customers
{
    public class CustomerService(
        ICustomerRepository repository,
        IMapper mapper,
        IValidator<CustomerCreateDto> createValidator,
        CustomerUpdateDtoValidator updateValidator) : ICustomerService
    {
        public async Task<IEnumerable<CustomerReadDto>> GetCustomersAsync()
        {
            IEnumerable<Customer> customer = await repository.GetAllAsync();
            return mapper.Map<IEnumerable<CustomerReadDto>>(customer);
        }

        public async Task<CustomerReadDto> CreateCustomerAsync(CustomerCreateDto dto)
        {
            await createValidator.ValidateAndThrowAsync(dto);
            Customer customer = mapper.Map<Customer>(dto);
            await repository.CreateAsync(customer);
            return mapper.Map<CustomerReadDto>(customer);
        }

        public async Task<CustomerReadDto> GetOneCustomerAsync(int id)
        {
            Customer? customer = await repository.GetOneAsync(id);
            return mapper.Map<CustomerReadDto>(customer);
        }

         public async Task<bool> UpdateCustomerAsync(int id, CustomerUpdateDto customerUpdateDto)
        {
            await updateValidator.ValidateAndThrowAsync(customerUpdateDto);

            var customer = await repository.GetOneAsync(id);

            if (customer == null)
            {
                return false;
            }

            mapper.Map(customerUpdateDto, customer);

            repository.Update(customer);
            await repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await repository.GetOneAsync(id);

            if (customer == null)
            {
                return false;
            }

            repository.Delete(customer);
            await repository.SaveChangesAsync();

            return true;
        }

    }
}
