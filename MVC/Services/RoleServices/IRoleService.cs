using MVC.Models;
using MVC.Models.RoleModels;

namespace MVC.Services.RoleServices;
public interface IRoleService
{
	Task<Response<bool>> CreateRoleAsync(CreateRoleDto model);
	Task<Response<bool>> UpdateRoleAsync(UpdateRoleDto model);
	Task<Response<bool>> DeleteRoleAsync(int roleId);
	Task<Response<GetRoleDto>> GetRoleByIdAsync(int roleId);
	Task<Response<List<GetRoleDto>>> GetRolesAsync();
}