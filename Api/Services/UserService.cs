public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<User> Create(User user)
    {
        var createdUser = await _repository.Create(user);
        return createdUser;
    }

    public async Task<User> GetById(Guid userId)
    {
        return await _repository.GetById(userId);
    }

    public async Task<User> Update(User user)
    {
        var updatedUser = await _repository.Update(user);
        return updatedUser;
    }

    public async Task<User> Delete(Guid userId)
    {
        return await _repository.Delete(userId);
    }
}