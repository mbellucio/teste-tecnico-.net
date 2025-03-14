using Microsoft.EntityFrameworkCore;

public class OrderRepository : IOrderRepository
{
    private readonly RepoPatternDbContext _context;
    private readonly IUserService _userService;

    public OrderRepository(RepoPatternDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Order> Create(Order order)
    {
        try
        {
            var user = await _userService.GetById(order.userId);

            if (order == null)
                throw new ArgumentNullException(nameof(order));

            var entity = new Order
            {
                Description = order.Description,
                Value = order.Value,
                user = order.User,
            };

            _context.Orders.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
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
            var user = await _userService.GetById(userId);

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return await _dbContext.Users
                .Include(u => u.Orders)
                .FirstOrDefaultAsync(u => u.Id == userId)
                ?.Orders
                .ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to find user orders: {ex.Message}");
            throw;
        }
    }

    public async Task<Order> Update(Order order)
    {
        try
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            var existingOrder = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == order.Id);

            if (existingOrder == null)
                return null;

            existingOrder.Description = order.Description;
            existingOrder.Value = order.Value;
            await _context.SaveChangesAsync();

            return existingOrder;
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
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
                return null;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return order;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting order: {ex.Message}");
            throw;
        }
    }
}