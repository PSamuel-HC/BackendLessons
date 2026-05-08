using MyStore.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Service.Employees
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeReadDto>> GetEmployeesAsync();
        Task<EmployeeReadDto> GetEmployeeAsync();
        Task<EmployeeReadDto> CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto);
    }
}
