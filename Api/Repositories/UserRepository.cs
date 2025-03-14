using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly RepoPatternDbContext _context;

    public UserRepository(RepoPatternDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<User> Create(User user)
    {
        try
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var entity = new User
            {
                Email = user.Email,
                Name = user.Name,
            };

            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating user: {ex.Message}");
            throw;
        }
    }

    public async Task<User> GetById(Guid userId)
    {
        try
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == userId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting user: {ex.Message}");
            throw;
        }
    }

    public async Task<User> Update(User user)
    {
        try
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == user.Id);

            if (existingUser == null)
                return null;

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            await _context.SaveChangesAsync();
            return existingUser;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating user: {ex.Message}");
            throw;
        }
    }

    public async Task<User> Delete(Guid userId)
    {
        try
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return null;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting user: {ex.Message}");
            throw;
        }
    }
}