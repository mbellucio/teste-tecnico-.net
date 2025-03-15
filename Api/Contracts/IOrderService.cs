public interface IOrderService
{
    Task<Order> Create(Order order);
    Task<PagedResponse<Order>> GetUserOrders(Guid userId, PaginationRequest pagination);
    Task<Order> Update(Guid id, Order order);
    Task<Order> Delete(Guid userId);
}