using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStore.API.DTOs;
using MyStore.Domain.Model;
using MyStore.Infrastructure;
using System.Globalization;

namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly MyStoreDbContext _context;

        public EmployeeController(MyStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeReadDto>>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();

            // MAPPING: Entity -> DTO
            var dtos = employees.Select(p => new EmployeeReadDto
            {
                Id = p.Id,
                FullName = p.FirstName + " " + p.LastName,
                Role = p.Role,
                HireDate = p.HireDate
            });

            return Ok(dtos);
        }

        // GET: api/employees/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<EmployeeReadDto>>> GetOneEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            // MAPPING: Entity -> DTO
            var employeeDto = new EmployeeReadDto
            {
                Id = employee.Id,
                FullName = employee.FirstName + " " + employee.LastName,
                Role = employee.Role,
                HireDate = employee.HireDate
            };
            return Ok(employeeDto);
        }


        // POST: api/employees
        [HttpPost]
        public async Task<ActionResult<EmployeeReadDto>> CreateEmployee(EmployeeCreateDto dto)
        {
            // 1. MAPPING: DTO -> Entity
            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Role = dto.Role,
                HourlyRate = dto.HourlyRate,
                HireDate = DateTime.ParseExact(dto.HireDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            };

            // 2. Persist to Database
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            // 3. Convert back to ReadDto to show the user the result (with the new ID)
            var resultDto = new EmployeeReadDto
            {
                Id = employee.Id,
                FullName = employee.FirstName + " " + employee.LastName,
                Role = employee.Role,
                HireDate = employee.HireDate
            };

            return CreatedAtAction(nameof(GetEmployees), new { id = resultDto.Id }, resultDto);
        }

        // PUT: api/employees/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeReadDto>> UpdateEmployee(int id, EmployeeUpdateDto dto)
        {
            // 1. Search if employee exists
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            // 2. Mapping: DTO -> Employee 
            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Role = dto.Role;
            employee.HourlyRate = dto.HourlyRate;
            employee.HireDate = DateTime.ParseExact(dto.HireDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            // 3. Persist on DB
            await _context.SaveChangesAsync();

            // 4. Returning 204 No Content
            return NoContent();
        }

        // DELETE: api/employees/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
