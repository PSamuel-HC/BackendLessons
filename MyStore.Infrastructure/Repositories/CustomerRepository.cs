using MyStore.Domain.Interfaces;
using MyStore.Domain.Model;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Infrastructure.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {
        public Task<Customer> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetOneAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
