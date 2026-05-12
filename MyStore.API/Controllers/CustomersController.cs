using Microsoft.AspNetCore.Mvc;
using MyStore.Service.DTOs;
using MyStore.Service.Customers;

namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CustomersController(ICustomerService customerService) : ControllerBase
    {

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetCustomers()
        {
            IEnumerable<CustomerReadDto> dtos = await customerService.GetCustomersAsync();

            return Ok(dtos);
        }

        // GET: api/customers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerReadDto>> GetCustomer(int id)
        {
            CustomerReadDto customer = await customerService.GetOneCustomerAsync(id);

        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

            return Ok(customer);
        }

        // POST: api/customers
        [HttpPost]
        public async Task<ActionResult<CustomerReadDto>> CreateCustomer(CustomerCreateDto dto)
        {

            CustomerReadDto resultDto = await customerService.CreateCustomerAsync(dto);

            return CreatedAtAction(nameof(GetCustomers), new { id = resultDto.Id }, resultDto);
        }

        // PUT: api/customers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerUpdateDto dto)
        {
            var updated = await customerService.UpdateCustomerAsync(id, dto);

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
            var deleted = await customerService.DeleteCustomerAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
