using AutoMapper;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Model;
using MyStore.Service.DTOs;

namespace MyStore.Service.Customers
{
    public class CustomerService(ICustomerRepository repository, IMapper mapper) : ICustomerService
    {
        public async Task<IEnumerable<CustomerReadDto>> GetCustomersAsync()
        {
            IEnumerable<Customer> customer = await repository.GetAllAsync();

            return mapper.Map<IEnumerable<CustomerReadDto>>(customer);
        }

        public async Task<CustomerReadDto> CreateCustomerAsync(CustomerCreateDto dto)
        {
            Customer customer = mapper.Map<Customer>(dto);
            await repository.CreateAsync(customer);
            return mapper.Map<CustomerReadDto>(customer);
        }

    }
}
