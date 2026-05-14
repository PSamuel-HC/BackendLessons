using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyStore.Service.DTOs;
using MyStore.Service.Employees;

namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EmployeesController(
    IEmployeeService employeeService,
    IValidator<EmployeeDto> validator) : ControllerBase
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
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
                return BadRequest(result.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));

            EmployeeReadDto employee = await employeeService.CreateEmployeeAsync(dto);
            return CreatedAtAction(nameof(GetEmployees), new { id = employee.Id }, employee);
        }

        // PUT: api/employees/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeReadDto>> UpdateEmployee(int id, EmployeeUpdateDto dto)
        {
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
            }

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
