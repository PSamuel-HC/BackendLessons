using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStore.API.DTOs;
using MyStore.Domain.Model;
using MyStore.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly MyStoreDbContext _context;
        
        public OrdersController(MyStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            
            var dtos = orders.Select(o => new OrderReadDto
            {
                Id = o.Id,
                OrderNumber = o.OrderNumber,
                CustomerName = o.CustomerName,
                TotalAmount = o.TotalAmount,
                Status = o.Status,
                ShippingAddress = o.ShippingAddress
            });

            return Ok(dtos);
     
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderReadDto>> GetById(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            return Ok(new OrderReadDto
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                CustomerName = order.CustomerName,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                ShippingAddress = order.ShippingAddress
            });
        }

        // POST: api/orders
        [HttpPost]
        public async Task<ActionResult<OrderReadDto>> CreateOrder(OrderCreateDto dto)
        {
            var order = new Order
            {
               OrderNumber = dto.OrderNumber,
               CustomerName = dto.CustomerName,
               TotalAmount = dto.TotalAmount,
               ShippingAddress = dto.ShippingAddress
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();


            var resultDto = new OrderReadDto
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                CustomerName = order.CustomerName,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                ShippingAddress = order.ShippingAddress
            };

            return CreatedAtAction(nameof(GetOrders), new { id = resultDto.Id }, resultDto);
            
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
