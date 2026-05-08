using AutoMapper;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Model;
using MyStore.Service.DTOs;
using System.Globalization;

namespace MyStore.Service.Employees
{
    public class EmployeeService(IEmployeeRepository repository, IMapper mapper) : IEmployeeService
    {
        public async Task<IEnumerable<EmployeeReadDto>> GetEmployeesAsync()
        {
            IEnumerable<Employee> employees = await repository.GetEmployeesAsync();
            return mapper.Map<IEnumerable<EmployeeReadDto>>(employees);
        }

        public Task<EmployeeReadDto> GetEmployeeAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<EmployeeReadDto> CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto)
        {
            Employee employee = mapper.Map<Employee>(employeeCreateDto);
            Employee newEmployee = await repository.AddEmployeeAsync(employee);
            return mapper.Map<EmployeeReadDto>(newEmployee);
        }
    }
}
