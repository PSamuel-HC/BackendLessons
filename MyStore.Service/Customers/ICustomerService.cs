using MyStore.Service.DTOs;

namespace MyStore.Service.Customers
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerReadDto>> GetCustomersAsync();

        Task<CustomerReadDto?> GetCustomerByIdAsync(int id);

        Task<CustomerReadDto> CreateCustomerAsync(CustomerCreateDto customerCreateDto);

        Task<bool> UpdateCustomerAsync(int id, CustomerUpdateDto customerUpdateDto);

        Task<bool> DeleteCustomerAsync(int id);
    }
}