using AutoMapper;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Model;
using MyStore.Service.DTOs;

namespace MyStore.Service.Employees
{
    public class EmployeeService(IEmployeeRepository repository, IMapper mapper) : IEmployeeService
    {
        public async Task<IEnumerable<EmployeeReadDto>> GetEmployeesAsync()
        {
            IEnumerable<Employee> employees = await repository.GetEmployeesAsync();
            return mapper.Map<IEnumerable<EmployeeReadDto>>(employees);
        }

        public async Task<EmployeeReadDto?> GetEmployeeByIdAsync(int id)
        {
            Employee? employee = await repository.GetEmployeeByIdAsync(id);
            return mapper.Map<EmployeeReadDto>(employee);
        }
        public async Task<EmployeeReadDto> CreateEmployeeAsync(EmployeeCreateDto employeeCreateDto)
        {
            Employee employee = mapper.Map<Employee>(employeeCreateDto);
            Employee newEmployee = await repository.AddEmployeeAsync(employee);
            return mapper.Map<EmployeeReadDto>(newEmployee);
        }

        public async Task<EmployeeReadDto?> UpdateEmployeeAsync(int id, EmployeeUpdateDto employeeUpdateDto)
        {
            Employee? employeefromDB = await repository.GetEmployeeByIdAsync(id);
            if (employeefromDB == null) return null;
            mapper.Map(employeeUpdateDto, employeefromDB);
            await repository.UpdateEmployeeAsync(employeefromDB);
            return mapper.Map<EmployeeReadDto>(employeefromDB);
        }

        public async Task<Boolean> DeleteEmployeeAsync(int id)
        {
            return await repository.DeleteEmployeeAsync(id);
        }

    }
}
