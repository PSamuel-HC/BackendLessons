using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Model;
using MyStore.Infrastructure;
using MyStore.Service.DTOs;
using System.Globalization;

namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController(IEmployeeService employeeService) : ControllerBase
    {
        // GET: api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeReadDto>>> GetEmployees()
        {
            IEnumerable<EmployeeReadDto> employees = await employeeService.GetEmployeesAsync();
            return Ok(employees);
        }

        // GET: api/employees/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeReadDto>> GetOneEmployee(int id)
        {
            EmployeeReadDto? employee = await employeeService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        // POST: api/employees
        [HttpPost]
        public async Task<ActionResult<EmployeeReadDto>> CreateEmployee(EmployeeCreateDto dto)
        {
            EmployeeReadDto employee = await employeeService.CreateEmployeeAsync(dto);
            return CreatedAtAction(nameof(GetEmployees), new { id = employee.Id }, employee);
        }

        // PUT: api/employees/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeReadDto>> UpdateEmployee(int id, EmployeeUpdateDto dto)
        {
            //// 1. Search if employee exists
            //var employee = await _context.Employees.FindAsync(id);

            //if (employee == null)
            //return NotFound();

            //// 2. Mapping: DTO -> Employee 
            //employee.FirstName = dto.FirstName;
            //employee.LastName = dto.LastName;
            //employee.Role = dto.Role;
            //employee.HourlyRate = dto.HourlyRate;
            //employee.HireDate = DateTime.ParseExact(dto.HireDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //// 3. Persist on DB
            //await _context.SaveChangesAsync();

            //// 4. Returning 204 No Content
            //return NoContent();


            EmployeeReadDto? editedEmployee = await employeeService.UpdateEmployeeAsync(id, dto);
            if (editedEmployee == null)
            {
                return NotFound();
            }
            return Ok(editedEmployee);


        }

        // DELETE: api/employees/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            Boolean employeeDeleted = await employeeService.DeleteEmployeeAsync(id);
            if (!employeeDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
