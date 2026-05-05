using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Model;

namespace MyStore.Infrastructure
{
    public class MyStoreDbContext : DbContext
    {
        public MyStoreDbContext(DbContextOptions<MyStoreDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } // This creates the "Products" table
        public DbSet<Employee> Employees { get; set; }
    }
}
