using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Model;

namespace MyStore.Infrastructure
{
    public class MyStoreDbContext : DbContext
    {
        public MyStoreDbContext(DbContextOptions<MyStoreDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } // This creates the "Products" table
        public DbSet<Employee> Employees { get; set; } // This creates the "Employees" table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Employee>()
                .Property(e => e.HourlyRate)
                .HasColumnType("decimal(18,2)");
        }
    }
}