using MVC.Entities;
namespace MVC.Repositories.RoleRepository;

public interface IRoleRepository
{
    Task<bool> CreateRole(Role model);
    Task<bool> UpdateRole(Role model);
    Task<bool> DeleteRole(string roleId);
    Task<List<UserRole>> GetRolesByUserId(string userId);
    Task<Role> GetRoleById(string roleId);
    Task<List<Role>> GetRoles();
    Task<bool> AddRoleToUser(string roleId, string userId);
    Task<bool> DeleteRoleInUser(string roleId, string userId);
}