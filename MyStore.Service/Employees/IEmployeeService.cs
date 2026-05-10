using MyStore.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Service.Employees
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeReadDto>> GetEmployeesAsync();
        Task<EmployeeReadDto?> GetEmployeeByIdAsync(int id);
        Task<EmployeeReadDto> CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto);
        Task<EmployeeReadDto?> UpdateEmployeeAsync(int id, EmployeeUpdateDto employeeUpdateDto);
        Task<Boolean> DeleteEmployeeAsync(int id);
    }
}
