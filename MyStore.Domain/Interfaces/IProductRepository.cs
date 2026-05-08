using MyStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetById(int id);
        Task Create(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}
