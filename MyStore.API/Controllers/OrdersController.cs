using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Model;
using MyStore.Infrastructure;
using MyStore.Service.DTOs;
using MyStore.Service.Orders;

namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController(IOrderService orderService) : ControllerBase
    {

        // GET: api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetOrders()
        {
            IEnumerable<OrderReadDto> orders = await orderService.GetOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderReadDto>> GetById(int id)
        {
            OrderReadDto? order = await orderService.GetOrderByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        // POST: api/orders
        [HttpPost]
        public async Task<ActionResult<OrderReadDto>> CreateOrder(OrderCreateDto dto)
        {
            OrderReadDto order = await orderService.CreateOrderAsync(dto);
            return Ok(order);
        }

        // PUT: api/orders/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, OrderUpdateDto dto)
        {
            bool created = await orderService.UpdateOrderAsync(id, dto);
            return created ? Ok() : NoContent();
        }

        // DELETE: api/orders/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            bool found_delete = await orderService.DeleteOrderAsync(id);
            if (!found_delete) return NotFound();
            return NoContent();
        }
    }
}
