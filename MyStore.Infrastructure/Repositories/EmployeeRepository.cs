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

        public async Task<Employee?> GetEmployeeByIdAsync(int id) => await context.Employees.FindAsync(id);

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

        public async Task<Boolean> DeleteEmployeeAsync(int id)
        {
            Employee? employee = await context.Employees.FindAsync(id);
            if (employee == null) return false;
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
