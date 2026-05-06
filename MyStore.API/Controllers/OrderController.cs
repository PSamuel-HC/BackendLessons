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

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetOrders()
        {
            var products = await _context.Products.ToListAsync();
            /*
                        // MAPPING: Entity -> DTO
                        var dtos = products.Select(p => new ProductReadDto
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Price = p.Price
                        });

                        return Ok(dtos);*/
            return Ok();  
        }

        // POST: api/products
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
    }
}
