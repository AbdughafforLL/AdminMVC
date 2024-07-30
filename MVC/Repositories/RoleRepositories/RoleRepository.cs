using MVC.Models.RoleModels;
using MVC.Utils;
namespace MVC.Repositories.RoleRepository;

public class RoleRepository : IRoleRepository
{
	public async Task<(bool,string)> CreateRoleAsync(CreateRoleDto model)
	{
		var parameters = new SqlParameter[] { 
			new SqlParameter("@query_id",1),
			new SqlParameter("@role_name",model.RoleName)
		};

		var (res, message) = await SQL.ExecuteNonQueryAsync("QueryRoles",parameters);
		return (res, message);
	}
	public async Task<(bool, string)> UpdateRoleAsync(UpdateRoleDto model)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",2),
			new SqlParameter("@role_id",model.RoleId),
			new SqlParameter("@role_name",model.RoleName)

		};
		var (res, message) = await SQL.ExecuteNonQueryAsync("QueryRoles", parameters);
		return (res, message);
	}
	public async Task<(bool, string)> DeleteRoleAsync(int roleId)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",3),
			new SqlParameter("@role_id",roleId),
		};
		var (res, message) = await SQL.ExecuteNonQueryAsync("QueryRoles", parameters);
		return (res, message);
	}
	public async Task<(string,DataTable?)> GetRoleByIdAsync(int roleId)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",4),
			new SqlParameter("@role_id",roleId),
		};
		var (res, dt) = await SQL.ExecuteQueryDataTableAsync("QueryRoles", parameters);
		return (res, dt);
	}
	public async Task<(string,DataTable?)> GetRolesAsync()
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",5)
		};
		var (res, dt) = await SQL.ExecuteQueryDataTableAsync("QueryRoles", parameters);
		return (res, dt);
	}
	public async Task<(bool,string)> AddRoleToUserAsync(int roleId, int userId)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",6),
			new SqlParameter("@user_id",userId),
			new SqlParameter("@role_id",roleId)
		};

		var (res, message) = await SQL.ExecuteNonQueryAsync("QueryRoles",parameters);
		return (res, message);
	}
	public async Task<(bool,string)> DeleteRoleFromUserAsync(int roleId, int userId)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id", 7),
			new SqlParameter("@user_id",userId),
			new SqlParameter("@role_id",roleId)
		};

		var (res, message) = await SQL.ExecuteNonQueryAsync("QueryRoles", parameters);
		return (res, message);
	}
}