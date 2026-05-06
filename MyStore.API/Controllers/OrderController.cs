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

        // GET: api/order
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
    }
}
