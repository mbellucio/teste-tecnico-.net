public interface IOrderRepository
{
    Task<Order> Create(Order order);
    Task<Order> GetUserOrders(Guid userId);
    Task<Order> Update(Order order);
    Task<Order> Delete(Guid userId);
}