using MVC.Entities;
using MVC.Models;
using MVC.Models.RoleModels;
using MVC.Repositories.RoleRepository;

namespace MVC.Services.RoleServices;
public class RoleService(IRoleRepository roleRepository,IMapper mapper) : IRoleService
{
	public async Task<Response<bool>> CreateRoleAsync(CreateRoleDto model)
	{
		var (res,message) = await roleRepository.CreateRoleAsync(mapper.Map<Role>(model));
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
		var (res, message) = await roleRepository.UpdateRoleAsync(mapper.Map<Role>(model));
		if (res) return new Response<bool>(res);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<GetRoleDto>> GetRoleByIdAsync(int roleId)
	{
		var (message, role) = await roleRepository.GetRoleByIdAsync(roleId);
		if (role is not null) return new Response<GetRoleDto>(mapper.Map<GetRoleDto>(role));
		return new Response<GetRoleDto>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<List<GetRoleDto>>> GetRolesAsync()
	{
		var (message, roles) = await roleRepository.GetRolesAsync();
		if (roles.Count>0) return new Response<List<GetRoleDto>>(mapper.Map<List<GetRoleDto>>(roles));
		return new Response<List<GetRoleDto>>(HttpStatusCode.InternalServerError, message);
	}
}