using MVC.Entities;
namespace MVC.Repositories.RoleRepository;

public interface IRoleRepository
{
	Task<(bool,string)> CreateRole(Role model);
	Task<(bool,string)> UpdateRole(Role model);
	Task<(bool,string)> DeleteRole(string roleId);
	Task<(bool,string,List<UserRole>)> GetRolesByUserId(string userId);
	Task<(string,Role?)> GetRoleById(string roleId);
	Task<(string,List<Role>)> GetRoles();
	Task<(bool,string)> AddRoleToUser(string roleId, string userId);
	Task<(bool,string)> DeleteRoleInUser(string roleId, string userId);
}