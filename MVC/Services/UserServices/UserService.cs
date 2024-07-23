using MVC.Models;
using MVC.Models.UserModels;
using MVC.Repositories.UserRepositories;
using System.Net;
namespace MVC.Services.UserServices;

public class UserService(IUserRepository userRepository) : IUserService
{
	public async Task<Response<bool>> CreateUserAsync(CreateUserDto model)
	{
		var (res, message) = await userRepository.CreateUser(model);
		if (res) return new Response<bool>(res);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<bool>> DeleteUserAsync(int userId)
	{
		var (res, message) = await userRepository.DeleteUser(userId);
		if (res) return new Response<bool>(res);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<bool>> UpdateUserAsync(UpdateUserDto model)
	{
		var (res, message) = await userRepository.UpdateUser(model);
		if (res) return new Response<bool>(res);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<GetUserByIdDto>> GetUserByIdAsync(int userId)
	{
		var (res, message, user) = await userRepository.GetUserById(userId);
		if (res) return new Response<GetUserByIdDto>(user!);
		return new Response<GetUserByIdDto>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<GetUserByUserName>> GetUserByUserNameAsync(string userName)
	{
		var (res, message, user) = await userRepository.GetUserByUserName(userName);
		if (res) return new Response<GetUserByUserName>(user!);
		return new Response<GetUserByUserName>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<List<GetUsersDto>>> GetUsersAsync()
	{
		var (res, message, users) = await userRepository.GetUsers();
		if (res) return new Response<List<GetUsersDto>>(users!);
		return new Response<List<GetUsersDto>>(HttpStatusCode.InternalServerError, message);
	}
}