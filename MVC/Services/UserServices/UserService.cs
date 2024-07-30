using MVC.Filters;
using MVC.Models;
using MVC.Models.UserModels;
using MVC.Repositories.UserRepositories;
namespace MVC.Services.UserServices;

public class UserService(IUserRepository userRepository,IMapper mapper) : IUserService
{
	public async Task<Response<bool>> CreateUserAsync(CreateUserDto model)
	{
		var (res, message) = await userRepository.CreateUserAsync(model, "test");
		if (res) return new Response<bool>(res);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<bool>> DeleteUserAsync(int userId)
	{
		var (res, message) = await userRepository.DeleteUserAsync(userId);
		if (res) return new Response<bool>(res);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<bool>> UpdateUserAsync(UpdateUserDto model)
	{
		var (res, message) = await userRepository.UpdateUserAsync(model);
		if (res) return new Response<bool>(res);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<GetUserByIdDto>> GetUserByIdAsync(int userId)
	{
		var (message, user) = await userRepository.GetUserByIdAsync(userId);
		if (user is null) return new Response<GetUserByIdDto>(HttpStatusCode.InternalServerError, message);
		return new Response<GetUserByIdDto>(mapper.Map<GetUserByIdDto>(user));
	}
	public async Task<Response<GetUserByIdDto>> GetUserByUserNameAsync(string userName)
	{
		var (message, user) = await userRepository.GetUserByUserNameAsync(userName);
		if (user != null) return new Response<GetUserByIdDto>(mapper.Map<GetUserByIdDto>(user));
		return new Response<GetUserByIdDto>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<List<GetUsersDto>>> GetUsersAsync(UserFilters model)
	{
		var (message, users) = await userRepository.GetUsersAsync(model);
		if (users.Count != 0) return new Response<List<GetUsersDto>>(mapper.Map<List<GetUsersDto>>(users));
		return new Response<List<GetUsersDto>>(HttpStatusCode.InternalServerError, message = message == "" ? "добавте ползователь" : message);
	}
	public async Task<Response<List<int>>> GetRolesByUserIdAsync(int user_id)
	{
		var (message,roles) = await userRepository.GetRolesByUserIdAsync(user_id);
		if (roles.Count < 1) return new Response<List<int>>(HttpStatusCode.InternalServerError,message = message == "" ? "not found" : message);
		return new Response<List<int>>(roles);
	}
}