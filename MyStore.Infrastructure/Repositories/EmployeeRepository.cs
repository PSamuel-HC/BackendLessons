using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Infrastructure.Repositories
{
    public class EmployeeRepository(MyStoreDbContext context) : IEmployeeRepository
    {
        public async Task<IEnumerable<Employee>> GetEmployeesAsync() => await context.Employees.ToListAsync();

        public async Task<Employee?> GetByIdAsync(int id) => await context.Employees.FindAsync(id);

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
            return employee;
        }

        public Task UpdateEmployeeAsync(Employee employee)
        {
            context.Employees.Update(employee);
            return Task.CompletedTask;
        }

        public Task DeleteEmployeeAsync(Employee employee)
        {
            context.Employees.Remove(employee);
            return Task.CompletedTask;
        }
    }
}
