using Microsoft.AspNetCore.Mvc;
using ModernWebApiDemo.Services.Orders;

namespace ModernWebApiDemo.Controllers;

[ApiController]
[Route("orders")]
public class OrdersController(IOrderService orderService) : ControllerBase
{
    private readonly IOrderService _orderService = orderService;

    [HttpPost]
    public async Task<IActionResult> Place([FromBody] PlaceOrderRequest request)
    {
        var order = await _orderService.PlaceOrderAsync(request);
        return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var order = await _orderService.GetOrderAsync(id);
        return order is null ? NotFound() : Ok(order);
    }
}
