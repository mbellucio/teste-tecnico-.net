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
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        if (await _context.Users.AnyAsync(u => u.Email == user.Email))
        {
            throw new InvalidOperationException("This email is already in use");
        }

        var entity = new User
        {
            Email = user.Email,
            Name = user.Name,
        };

        _context.Users.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<User> GetById(Guid userId)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("User ID must be provided.", nameof(userId));

        return await _context.Users
            .FirstOrDefaultAsync(user => user.Id == userId);
    }

    public async Task<User> Update(Guid id, User user)
    {
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);

        ArgumentNullException.ThrowIfNull(existingUser, nameof(user));

        if (user.Email != null)
            existingUser.Email = user.Email;

        if (user.Name != null)
            existingUser.Name = user.Name;

        await _context.SaveChangesAsync();
        return existingUser;
    }

    public async Task<User> Delete(Guid userId)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == userId);

        ArgumentNullException.ThrowIfNull(user, nameof(user));

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }
}