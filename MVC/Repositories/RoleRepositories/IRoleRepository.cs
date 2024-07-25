using MVC.Entities;
namespace MVC.Repositories.RoleRepository;

public interface IRoleRepository
{
	Task<(bool,string)> CreateRoleAsync(Role model);
	Task<(bool,string)> UpdateRoleAsync(Role model);
	Task<(bool,string)> DeleteRoleAsync(int roleId);
	Task<(string,Role?)> GetRoleByIdAsync(int roleId);
	Task<(string,List<Role>)> GetRolesAsync();
	Task<(string,List<UserRole>)> GetRolesByUserIdAsync(int userId);
	Task<(bool,string)> AddRoleToUserAsync(int roleId, int userId);
	Task<(bool,string)> DeleteRoleFromUserAsync(int roleId, int userId);
}