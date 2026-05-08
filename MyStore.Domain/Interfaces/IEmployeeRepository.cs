using MyStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task<Boolean> DeleteEmployeeAsync(int id);
    }
}
