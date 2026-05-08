using MyStore.Domain.Model;

namespace MyStore.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task AddAsync(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        Task SaveChangesAsync();
    }
}