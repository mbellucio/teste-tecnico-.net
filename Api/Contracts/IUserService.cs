public interface IUserService
{
    Task<User> Create(User user);
    Task<User> GetById(Guid userId);
    Task<User> Update(User user);
    Task<User> Delete(Guid userId);
}