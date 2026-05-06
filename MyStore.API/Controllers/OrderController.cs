using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStore.API.DTOs;
using MyStore.Domain.Model;
using MyStore.Infrastructure;

namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly MyStoreDbContext _context;

        public OrderController(MyStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetOrders()
        {
            var products = await _context.Products.ToListAsync();
            
            // MAPPING: Entity -> DTO
            var dtos = products.Select(p => new ProductReadDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            });

            return Ok(dtos);
        }

        // POST: api/orders
        [HttpPost]
        public async Task<ActionResult<ProductReadDto>> CreateProduct(ProductCreateDto dto)
        {
            // 1. MAPPING: DTO -> Entity
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price
            };

            // 2. Persist to Database
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            // 3. Convert back to ReadDto to show the user the result (with the new ID)
            var resultDto = new ProductReadDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            // return CreatedAtAction(nameof(GetProducts), new { id = resultDto.Id }, resultDto);
            return Ok();
        }

        // PUT: api/orders/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, OrderUpdateDto dto)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            // Update fields
            order.TotalAmount = dto.TotalAmount ?? order.TotalAmount;
            order.CustomerName = dto.CustomerName ?? order.CustomerName;
            order.ShippingAddress = dto.ShippingAddress ?? order.ShippingAddress;
            order.Status = dto.Status ?? order.Status;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/orders/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
