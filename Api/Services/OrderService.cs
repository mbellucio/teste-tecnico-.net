public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<Order> Create(Order order)
    {
        try
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            var createdOrder = await _repository.Create(order);
            return createdOrder;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating order: {ex.Message}");
            throw;
        }
    }

    public async Task<List<Order>> GetUserOrders(Guid userId)
    {
        try
        {
            return await _repository.GetUserOrders(userId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting orders: {ex.Message}");
            throw;
        }
    }

    public async Task<Order> Update(Order order)
    {
        try
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            var updatedOrder = await _repository.Update(order);
            return updatedOrder;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating order: {ex.Message}");
            throw;
        }
    }

    public async Task<Order> Delete(Guid orderId)
    {
        try
        {
            return await _repository.Delete(orderId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting order: {ex.Message}");
            throw;
        }
    }

}

