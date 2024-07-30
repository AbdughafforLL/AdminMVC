using MVC.Filters;
using MVC.Models.UserModels;
namespace MVC.Repositories.UserRepositories;
public interface IUserRepository
{
	Task<(bool, string)> CreateUserAsync(CreateUserDto model,string hashPassword);
	Task<(bool, string)> UpdateUserAsync(UpdateUserDto model);
	Task<(bool, string)> DeleteUserAsync(int userId);
	Task<(string, GetUserByIdDto?)> GetUserByUserNameAsync(string userName);
	Task<(string, GetUserByIdDto?)> GetUserByIdAsync(int userId);
	Task<(string, List<GetUsersDto>)> GetUsersAsync(UserFilters model);
	Task<(string, List<int>)> GetRolesByUserIdAsync(int userId);
}