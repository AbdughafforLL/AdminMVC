using MVC.Filters;
using MVC.Helpers;
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
		var (message, ds) = await userRepository.GetUserByIdAsync(userId);
		if (ds is null) return new Response<GetUserByIdDto>(HttpStatusCode.InternalServerError, message);
		var user = new GetUserByIdDto();
		foreach (var dr in ds.Tables[0].Rows)
			user = mapper.Map<GetUserByIdDto>(dr);
		return new Response<GetUserByIdDto>(mapper.Map<GetUserByIdDto>(user));
	}
	public async Task<Response<GetUserByIdDto>> GetUserByUserNameAsync(string userName)
	{
		var (message, ds) = await userRepository.GetUserByUserNameAsync(userName);
		if (ds is null) return new Response<GetUserByIdDto>(HttpStatusCode.BadRequest, message);
		var user = new GetUserByIdDto();
		foreach (var dr in ds.Tables[0].Rows)
			user = mapper.Map<GetUserByIdDto>(dr);
		return new Response<GetUserByIdDto>(mapper.Map<GetUserByIdDto>(user));
	}
	public async Task<Response<List<GetUsersDto>>> GetUsersAsync(UserFilters model)
	{
		var (message, dt) = await userRepository.GetUsersAsync(model);
		if (dt is null) return new Response<List<GetUsersDto>>(HttpStatusCode.InternalServerError, message = message == "" ? "добавте ползователь" : message);
		var users = MapHelper.MapDataTableToList<GetUsersDto>(dt, mapper);
		return new Response<List<GetUsersDto>>(users);
	}
	public async Task<Response<List<int>>> GetRolesByUserIdAsync(int user_id)
	{
		var (message,dt) = await userRepository.GetRolesByUserIdAsync(user_id);
		if (dt is null) return new Response<List<int>>(HttpStatusCode.InternalServerError,message = message == "" ? "not found" : message);
		var roles = new List<int>();
        foreach (var dr in dt.Rows)
			roles.Add((int)dr);
        return new Response<List<int>>(roles);
	}
}