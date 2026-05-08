using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStore.Service.DTOs;
using MyStore.Domain.Model;
using MyStore.Infrastructure;

namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly MyStoreDbContext _context;

        public CustomersController(MyStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();

            // MAPPING: Entity -> DTO
            var dtos = customers.Select(c => new CustomerReadDto
            {
                Id = c.Id,
                Email = c.Email,
                FullName = c.FullName,
                PointsBalance = c.PointsBalance,
                IsPremium = c.IsPremium,
                LastPurchaseDate = c.LastPurchaseDate,
            });

            return Ok(dtos);
        }

        // GET: api/customers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerReadDto>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            var resultDto = new CustomerReadDto
            {
                Id = customer.Id,
                Email = customer.Email,
                FullName = customer.FullName,
                PointsBalance = customer.PointsBalance,
                IsPremium = customer.IsPremium,
            };

            return Ok(resultDto);
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<CustomerReadDto>> CreateCustomer(CustomerCreateDto dto)
        {
            // 1. MAPPING: DTO -> Entity
            var customer = new Customer
            {
                Email = dto.Email,
                FullName = dto.FullName,
                IsPremium = dto.IsPremium,
            };

            // 2. Persist to Database
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            // 3. Convert back to ReadDto to show the user the result (with the new ID)
            var resultDto = new CustomerReadDto
            {
                Id = customer.Id,
                Email = customer.Email,
                FullName = customer.FullName,
                PointsBalance = customer.PointsBalance,
                IsPremium = customer.IsPremium,
                LastPurchaseDate = customer.LastPurchaseDate,
            };

            return CreatedAtAction(nameof(GetCustomers), new { id = resultDto.Id }, resultDto);
        }

        // PUT: api/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(int id, CustomerUpdateDto dto) {

            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            customer.Email = dto.Email;
            customer.FullName = dto.FullName;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/customers/{id}
        [HttpDelete("{id}")] 
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
