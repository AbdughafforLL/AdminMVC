using MVC.Entities;

namespace MVC.Repositories.RoleRepository;

public interface IRoleRepository
{
    Task<bool> CreateRole(Role model);
    Task<bool> UpdateRole(Role model);
    Task<bool> DeleteRole(string roleId);
    Task<List<UserRole>> GetRolesByUserId(int userId);
    Task<Role> GetRoleById(int roleId);
    Task<List<Role>> GetRoles();
}