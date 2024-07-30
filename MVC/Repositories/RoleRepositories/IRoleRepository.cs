using MVC.Models.RoleModels;
namespace MVC.Repositories.RoleRepository;

public interface IRoleRepository
{
	Task<(bool,string)> CreateRoleAsync(CreateRoleDto model);
	Task<(bool,string)> UpdateRoleAsync(UpdateRoleDto model);
	Task<(bool,string)> DeleteRoleAsync(int roleId);
	Task<(string,DataTable?)> GetRoleByIdAsync(int roleId);
	Task<(string,DataTable?)> GetRolesAsync();
	Task<(bool,string)> AddRoleToUserAsync(int roleId, int userId);
	Task<(bool,string)> DeleteRoleFromUserAsync(int roleId, int userId);
}