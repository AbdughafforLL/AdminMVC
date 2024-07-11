using MVC.Entities;
namespace MVC.Repositories.UserRepositories;

public interface IUserRepository
{
       Task<bool> CreateUser(User model);
       Task<bool> UpdateUser(User model);
       Task<bool> DeleteUser(int userId);
       Task<User> GetUserByUserName(string userName);
       Task<User> GetUserById(int userId);
       Task<List<User>> GetUsers();
}