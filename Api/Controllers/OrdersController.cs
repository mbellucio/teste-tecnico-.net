using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("pedidos")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService service)
    {
        _orderService = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost("")]
    public async Task<ActionResult<User>> Create(Order order)
    {
        var createdOrder = await _orderService.Create(order);
        return Ok(createdOrder);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<Order>>> GetUserOrders(Guid id)
    {
        var orders = await _orderService.GetUserOrders(id);
        return orders != null ? Ok(orders) : NotFound();
    }

    [HttpPut]
    public async Task<ActionResult<Order>> Update(Order order)
    {
        var updatedOrder = await _orderService.Update(order);
        return updatedOrder != null ? Ok(updatedOrder) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Order>> Delete(Guid id)
    {
        var deletedOrder = await _orderService.Delete(id);
        return deletedOrder != null ? Ok(deletedOrder) : NotFound();
    }
}