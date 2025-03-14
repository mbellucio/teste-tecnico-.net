public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<User> Create(User user)
    {
        try
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var createdUser = await _repository.Create(user);
            return createdUser;
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
            return await _repository.GetById(userId);
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

            var updatedUser = await _repository.Update(user);
            return updatedUser;
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
            return await _repository.Delete(userId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting user: {ex.Message}");
            throw;
        }
    }
}