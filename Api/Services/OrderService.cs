public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<Order> Create(Order order)
    {
        var createdOrder = await _repository.Create(order);
        return createdOrder;
    }

    public async Task<List<Order>> GetUserOrders(Guid userId)
    {
        return await _repository.GetUserOrders(userId);
    }

    public async Task<Order> Update(Guid id, Order order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));

        var updatedOrder = await _repository.Update(id, order);
        return updatedOrder;
    }

    public async Task<Order> Delete(Guid orderId)
    {
        return await _repository.Delete(orderId);
    }
}

