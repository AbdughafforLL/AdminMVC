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
		var (message, dt) = await userRepository.DeleteUserAsync(userId);
		var res = MapHelper.DataTableToInt(dt,"status_code");
		if (res != 1) return new Response<bool>(HttpStatusCode.InternalServerError, message);
		return new Response<bool>(true);

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
		GetUserByIdDto user = new ();
        foreach (var dr in ds.Tables[0].Rows)
			user = mapper.Map<GetUserByIdDto>(dr);
		user.Roles = MapHelper.DataTableToList(ds.Tables[1],"roles");
		user.Areas = MapHelper.DataTableToList(ds.Tables[2],"areas");
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
	public async Task<Response<GetUserWithFlters>> GetUsersAsync(UserFilters model)
	{
		var (message, ds) = await userRepository.GetUsersAsync(model);
		if (ds is null) return new Response<GetUserWithFlters>(HttpStatusCode.InternalServerError, string.IsNullOrEmpty(message) ? "добавте ползователь" : message);
		model.TotalRecords = MapHelper.DataTableToInt(ds.Tables[1],"count");
		model.PageCount = (int)Math.Ceiling(model.TotalRecords / (double)model.PageSize);
		var users = new GetUserWithFlters(){
			Users = MapHelper.MapDataTableToList<GetUsersDto>(ds.Tables[0], mapper),
			Filter = model
		};
		return new Response<GetUserWithFlters>(users);
	}
	public async Task<Response<List<int>>> GetRolesByUserIdAsync(int user_id)
	{
		var (message,dt) = await userRepository.GetRolesByUserIdAsync(user_id);
		if (dt is null) return new Response<List<int>>(HttpStatusCode.InternalServerError, string.IsNullOrEmpty(message) ? "not found" : message);
		var roles = MapHelper.DataTableToList(dt,"role_id");
        return new Response<List<int>>(roles);
	}
}