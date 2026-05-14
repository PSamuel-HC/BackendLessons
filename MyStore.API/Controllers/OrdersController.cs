using Microsoft.AspNetCore.Mvc;
using MyStore.Service.Orders;
using FluentValidation;
using MyStore.Service.DTOs.OrderDTOs;


namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
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
            try
            {
                OrderReadDto order = await orderService.CreateOrderAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new
                {
                    errors = ex.Errors.Select(e => e.ErrorMessage)
                });
            }
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
