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

    /// <summary>
    /// Creates a new order for a user.
    /// </summary>
    /// <param name="order">The order details to create.</param>
    /// <returns>The newly created order.</returns>
    /// <response code="200">Returns the created order.</response>
    /// <response code="400">If the order data is invalid or missing.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Order>> Create([FromBody] CreateOrderDto orderDto)
    {
        var order = new Order
        {
            Description = orderDto.Description,
            Value = orderDto.Value,
            UserId = orderDto.userId
        };
        var createdOrder = await _orderService.Create(order);
        return Ok(createdOrder);
    }


    /// <summary>
    /// Return all orders from a user
    /// </summary>
    /// <param name="usuarioId">The user id to return it's orders</param>
    /// <returns>All user orders.</returns>
    /// <response code="200">Returns all user orders.</response>
    /// <response code="404">If the order data is invalid or missing.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpGet("{usuarioId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<Order>>> GetUserOrders(Guid id)
    {
        var orders = await _orderService.GetUserOrders(id);
        return orders != null ? Ok(orders) : NotFound();
    }

    /// <summary>
    /// Updates an existing order
    /// </summary>
    /// <param name="order">The order details to update.</param>
    /// <returns>The newly updated order.</returns>
    /// <response code="200">Returns the updated order.</response>
    /// <response code="404">If the order data is invalid or missing.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Order>> Update([FromBody] UpdateOrderDto orderDto)
    {
        var order = new Order
        {
            Description = orderDto.Description,
            Value = orderDto.Value,
        };
        var updatedOrder = await _orderService.Update(order);
        return updatedOrder != null ? Ok(updatedOrder) : NotFound();
    }

    /// <summary>
    /// Deletes an order
    /// </summary>
    /// <param name="id">the order id.</param>
    /// <returns>The newly deleted order</returns>
    /// <response code="200">Returns the deleted order.</response>
    /// <response code="404">If the order data is invalid or missing.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Order>> Delete(Guid id)
    {
        var deletedOrder = await _orderService.Delete(id);
        return deletedOrder != null ? Ok(deletedOrder) : NotFound();
    }
}