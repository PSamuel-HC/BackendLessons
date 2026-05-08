using MyStore.Service.DTOs;

namespace MyStore.Service.Customers
{
    public interface ICustomerService
    {
        public Task<IEnumerable<CustomerReadDto>> GetCustomersAsync();
    }
}
