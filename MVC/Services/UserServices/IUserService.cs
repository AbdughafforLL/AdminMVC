using MVC.Models;
using MVC.Models.UserModels;
namespace MVC.Services.UserServices;

public interface IUserService
{
	Task<Response<bool>> CreateUserAsync(CreateUserDto model);
	Task<Response<bool>> DeleteUserAsync(int userId);
	Task<Response<bool>> UpdateUserAsync(UpdateUserDto model);
	Task<Response<GetUserByIdDto>> GetUserByIdAsync(int userId);
	Task<Response<GetUserByUserName>> GetUserByUserNameAsync(string userName);
	Task<Response<List<GetUsersDto>>> GetUsersAsync();
}