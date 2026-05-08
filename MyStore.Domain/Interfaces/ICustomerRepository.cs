using MyStore.Domain.Model;

namespace MyStore.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetOneAsync();
        Task<Customer> CreateAsync();
        void UpdateAsync();
        void DeleteAsync();
    }
}
