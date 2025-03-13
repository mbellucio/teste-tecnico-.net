using User;

public interface IUserRepository
{
   User Create(User user);
   User GetById(Guid userId);
   User Update(User user);
   User Delete(Guid userId);
}