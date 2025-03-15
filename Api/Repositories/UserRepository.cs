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
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Id == userId); 
    }

    public async Task<User> Update(User user)
    {
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == user.Id);

        ArgumentNullException.ThrowIfNull(existingUser, nameof(user));

        existingUser.Name = user.Name;
        existingUser.Email = user.Email;

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