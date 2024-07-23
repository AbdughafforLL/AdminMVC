using MVC.Filters;
using MVC.Models.UserModels;
namespace MVC.Repositories.UserRepositories;

public interface IUserRepository
{
	Task<(bool, string)> CreateUser(CreateUserDto model);
	Task<(bool, string)> UpdateUser(UpdateUserDto model);
	Task<(bool, string)> DeleteUser(int userId);
	Task<(string, GetUserByUserName?)> GetUserByUserName(string userName);
	Task<(string, GetUserByIdDto?)> GetUserById(int userId);
	Task<(string, List<GetUsersDto>)> GetUsers(UserFilters model);
}