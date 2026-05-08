using Microsoft.AspNetCore.Mvc;
using MyStore.Service.Customers;
using MyStore.Service.DTOs;

namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetCustomers()
        {
            var customers = await _customerService.GetCustomersAsync();

            return Ok(customers);
        }

        // GET: api/customers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerReadDto>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // POST: api/customers
        [HttpPost]
        public async Task<ActionResult<CustomerReadDto>> CreateCustomer(CustomerCreateDto dto)
        {
            var customer = await _customerService.CreateCustomerAsync(dto);

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        // PUT: api/customers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerUpdateDto dto)
        {
            var updated = await _customerService.UpdateCustomerAsync(id, dto);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/customers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var deleted = await _customerService.DeleteCustomerAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}