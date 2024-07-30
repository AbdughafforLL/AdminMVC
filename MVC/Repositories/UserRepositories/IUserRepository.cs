using MVC.Filters;
using MVC.Models.UserModels;
namespace MVC.Repositories.UserRepositories;
public interface IUserRepository
{
	Task<(bool, string)> CreateUserAsync(CreateUserDto model,string hashPassword);
	Task<(bool, string)> UpdateUserAsync(UpdateUserDto model);
	Task<(bool, string)> DeleteUserAsync(int userId);
	Task<(string, DataSet?)> GetUserByUserNameAsync(string userName);
	Task<(string, DataSet?)> GetUserByIdAsync(int userId);
	Task<(string, DataTable?)> GetUsersAsync(UserFilters model);
	Task<(string, DataTable?)> GetRolesByUserIdAsync(int userId);
}