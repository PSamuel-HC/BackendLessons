using MyStore.Service.DTOs;

namespace MyStore.Service.Customers
{
    public interface ICustomerService
    {
        public Task<IEnumerable<CustomerReadDto>> GetCustomersAsync();
        public Task<CustomerReadDto> CreateCustomerAsync(CustomerCreateDto dto);
        public Task<CustomerReadDto> GetOneCustomerAsync(int id);
    }
}
