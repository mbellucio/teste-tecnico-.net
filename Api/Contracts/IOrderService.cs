public interface IOrderService
{
    Task<Order> Create(Order order);
    Task<List<Order>> GetUserOrders(Guid userId);
    Task<Order> Update(Guid id, Order order);
    Task<Order> Delete(Guid userId);
}