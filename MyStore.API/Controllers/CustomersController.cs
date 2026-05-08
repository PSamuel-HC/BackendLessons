using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStore.Service.DTOs;
using MyStore.Domain.Model;
using MyStore.Infrastructure;
using MyStore.Service.Customers;

namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController(ICustomerService customerService) : ControllerBase
    {

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetCustomers()
        {
            IEnumerable<CustomerReadDto> dtos = await customerService.GetCustomersAsync();

            return Ok(dtos);
        }

        //// GET: api/customers/{id}
        //[HttpGet("{id}")]
        //public async Task<ActionResult<CustomerReadDto>> GetCustomer(int id)
        //{
        //    var customer = await _context.Customers.FindAsync(id);

        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    var resultDto = new CustomerReadDto
        //    {
        //        Id = customer.Id,
        //        Email = customer.Email,
        //        FullName = customer.FullName,
        //        PointsBalance = customer.PointsBalance,
        //        IsPremium = customer.IsPremium,
        //    };

        //    return Ok(resultDto);
        //}

        // POST: api/customers
        [HttpPost]
        public async Task<ActionResult<CustomerReadDto>> CreateCustomer(CustomerCreateDto dto)
        {

            CustomerReadDto resultDto = await customerService.CreateCustomerAsync(dto);

            return CreatedAtAction(nameof(GetCustomers), new { id = resultDto.Id }, resultDto);
        }

        //// PUT: api/{id}
        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateCustomer(int id, CustomerUpdateDto dto) {

        //    var customer = await _context.Customers.FindAsync(id);

        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    customer.Email = dto.Email;
        //    customer.FullName = dto.FullName;

        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //// DELETE: api/customers/{id}
        //[HttpDelete("{id}")] 
        //public async Task<ActionResult> DeleteCustomer(int id)
        //{
        //    var customer = await _context.Customers.FindAsync(id);

        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Customers.Remove(customer);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}
