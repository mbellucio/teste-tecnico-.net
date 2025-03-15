using Microsoft.EntityFrameworkCore;

public class OrderRepository : IOrderRepository
{
    private readonly RepoPatternDbContext _context;
    private readonly IUserService _userService;

    public OrderRepository(RepoPatternDbContext context, IUserService userService)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public async Task<Order> Create(Order order)
    {
        ArgumentNullException.ThrowIfNull(order, nameof(order));

        var user = await _userService.GetById(order.UserId);
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        var entity = new Order
        {
            Description = order.Description,
            Value = order.Value,
            UserId = order.UserId,
        };

        _context.Orders.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<PagedResponse<Order>> GetUserOrders(Guid userId, PaginationRequest pagination)
    {
        if (pagination.PageNumber <= 0)
            pagination.PageNumber = 1;

        if (pagination.PageSize <= 0)
            pagination.PageSize = 5;

        var user = await _userService.GetById(userId);
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        var query = _context.Orders.Where(o => o.UserId == userId);
        var totalRecords = await query.CountAsync();
        
        var orders = await query
            .OrderBy(o => o.OrderDate)
            .Skip((pagination.PageNumber - 1) * pagination.GetPageSize())
            .Take(pagination.GetPageSize())
            .ToListAsync();

        return new PagedResponse<Order>(orders, pagination.PageNumber, pagination.GetPageSize(), totalRecords);
    }

    public async Task<Order> Update(Guid id, Order order)
    {
        ArgumentNullException.ThrowIfNull(order, nameof(order));

        if (id == Guid.Empty)
            throw new ArgumentException("Order ID must be provided.", nameof(id));

        var existingOrder = await _context.Orders
            .FirstOrDefaultAsync(o => o.Id == id);

        ArgumentNullException.ThrowIfNull(existingOrder, nameof(order));

        if (order.Description != null)
            existingOrder.Description = order.Description;

        if (order.Value != existingOrder.Value && order.Value != 0)
            existingOrder.Value = order.Value;

        await _context.SaveChangesAsync();
        return existingOrder;
    }

    public async Task<Order> Delete(Guid orderId)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.Id == orderId);

        ArgumentNullException.ThrowIfNull(order, nameof(order));

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return order;
    }
}