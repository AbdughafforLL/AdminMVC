using MVC.Entities;
using MVC.Filters;
using MVC.Models.UserModels;
namespace MVC.Repositories.UserRepositories;
public interface IUserRepository
{
	Task<(bool, string)> CreateUserAsync(User model);
	Task<(bool, string)> UpdateUserAsync(User model);
	Task<(bool, string)> DeleteUserAsync(int userId);
	Task<(string, User?)> GetUserByUserNameAsync(string userName);
	Task<(string, User?)> GetUserByIdAsync(int userId);
	Task<(string, List<User>)> GetUsersAsync(UserFilters model);
	Task<(string, List<int>)> GetRolesByUserIdAsync(int userId);
}