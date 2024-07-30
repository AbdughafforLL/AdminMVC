using MVC.Helpers;
using MVC.Models;
using MVC.Models.RoleModels;
using MVC.Repositories.RoleRepository;

namespace MVC.Services.RoleServices;
public class RoleService(IRoleRepository roleRepository,IMapper mapper) : IRoleService
{
	public async Task<Response<bool>> CreateRoleAsync(CreateRoleDto model)
	{
		var (res,message) = await roleRepository.CreateRoleAsync(model);
		if (res) return new Response<bool>(res);
		return new Response<bool>(HttpStatusCode.InternalServerError,message);
	}
	public async Task<Response<bool>> DeleteRoleAsync(int roleId)
	{
		var (res, message) = await roleRepository.DeleteRoleAsync(roleId);
		if (res) return new Response<bool>(res);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<bool>> UpdateRoleAsync(UpdateRoleDto model)
	{
		var (res, message) = await roleRepository.UpdateRoleAsync(model);
		if (res) return new Response<bool>(res);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<GetRoleDto>> GetRoleByIdAsync(int roleId)
	{
		var (message, dt) = await roleRepository.GetRoleByIdAsync(roleId);
		if (dt is null) return new Response<GetRoleDto>(HttpStatusCode.InternalServerError, message);
		var role = mapper.Map<GetRoleDto>(dt);
		return new Response<GetRoleDto>(role);
	}
	public async Task<Response<List<GetRoleDto>>> GetRolesAsync()
	{
		var (message, dt) = await roleRepository.GetRolesAsync();
		if (dt is null) return new Response<List<GetRoleDto>>(HttpStatusCode.InternalServerError, message);
		var roles = MapHelper.MapDataTableToList<GetRoleDto>(dt,mapper);
		return new Response<List<GetRoleDto>>(roles);
	}
}