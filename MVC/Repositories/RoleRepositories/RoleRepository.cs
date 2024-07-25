using MVC.Entities;
using MVC.Models;
namespace MVC.Repositories.RoleRepository;

public class RoleRepository(IConfiguration configuration) : IRoleRepository
{
	private readonly SqlAdoModel _ado = new()
	{
		ConString = configuration.GetConnectionString("DefaultConnection")!
	};

	public async Task<(bool,string)> CreateRoleAsync(Role model)
	{
		_ado.SqlQuery = "insert into Roles(role_name) Values(@role_name);";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@role_name", model.RoleName);
					_ado.Connection.Open();
					int i = _ado.Command.ExecuteNonQuery();
					_ado.Connection.Close();
					return (Convert.ToBoolean(i),"");
				}
			});
		}
		catch (Exception ex)
		{
			return (false, ex.Message);
		}
	}
	public async Task<(bool, string)> UpdateRoleAsync(Role model)
	{
		_ado.SqlQuery = "update from Roles set role_name = @role_name where role_id = @role_id;";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@role_id", model.RoleId);
					_ado.Command.Parameters.AddWithValue("@role_name", model.RoleName);
					_ado.Connection.Open();
					int i = _ado.Command.ExecuteNonQuery();
					_ado.Connection.Close();
					return (Convert.ToBoolean(i), "");
				}
			});
		}
		catch (Exception ex)
		{
			return (false, ex.Message);
		}
	}
	public async Task<(bool, string)> DeleteRoleAsync(int roleId)
	{
		_ado.SqlQuery = "delete from Roles where role_id = @role_id;";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.SqlQuery))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@role_id", roleId);
					_ado.Connection.Open();
					int i = _ado.Command.ExecuteNonQuery();
					_ado.Connection.Close();
					return (Convert.ToBoolean(i), "");
				}
			});
		}
		catch (Exception ex)
		{
			return (false, ex.Message);
		}
	}
	public async Task<(string,Role?)> GetRoleByIdAsync(int roleId)
	{
		Role role = null!;
		_ado.SqlQuery = "select * from Roles where role_id = @role_id;";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@role_id", roleId);
					_ado.Connection.Open();
					_ado.DataReader = _ado.Command.ExecuteReader();
					while (_ado.DataReader.Read())
					{
						role = new Role()
						{
							RoleId = (int)_ado.DataReader["role_id"],
							RoleName = (string)_ado.DataReader["role_name"],
							CreatedAt = (string)_ado.DataReader["created_at"],
							UpdatedAt = (string)_ado.DataReader["updated_at"]
						};
					}
					_ado.Connection.Close();
				}
				return ("",role);
			});
		}
		catch (Exception ex)
		{
			return (ex.Message,role);
		}
	}
	public async Task<(string,List<Role>)> GetRolesAsync()
	{
		List<Role> roles = new();
		_ado.SqlQuery = "select * from Roles;";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;

					_ado.Connection.Open();
					_ado.DataReader = _ado.Command.ExecuteReader();
					while (_ado.DataReader.Read())
					{
						var role = new Role()
						{
							RoleId = (int)_ado.DataReader["role_id"],
							RoleName = (string)_ado.DataReader["role_name"],
							CreatedAt= (string)_ado.DataReader["created_at"],
							UpdatedAt = (string)_ado.DataReader["updated_at"]
						};
						roles.Add(role);
					}
					_ado.Connection.Close();
				}
				return ("",roles);
			});
		}
		catch (Exception ex)
		{
			return (ex.Message,roles);
		}
	}
	public async Task<(string,List<UserRole>)> GetRolesByUserIdAsync(int userId)
	{
		List<UserRole> roles = new();
		_ado.SqlQuery = "select * from UserRoles where user_id = @user_id;";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@user_id", userId);
					_ado.Connection.Open();
					_ado.DataReader = _ado.Command.ExecuteReader();
					while (_ado.DataReader.Read())
					{
						var role = new UserRole()
						{
							RoleId = (int)_ado.DataReader["role_id"],
							UserId = (int)_ado.DataReader["user_id"],
							CreatedAt = (string)_ado.DataReader["created_at"],
							UpdatedAt = (string)_ado.DataReader["updated_at"]
						};
						roles.Add(role);
					}
					_ado.Connection.Close();
				}
				return ("",roles);
			});
		}
		catch (Exception ex)
		{
			return (ex.Message,roles);
		}
	}
	public async Task<(bool,string)> AddRoleToUserAsync(int roleId, int userId)
	{
		_ado.SqlQuery = "insert into UserRoles(user_id,role_id) Values(@user_id,@role_id);";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@user_id", userId);
					_ado.Command.Parameters.AddWithValue("@role_id", roleId);
					_ado.Connection.Open();
					int i = _ado.Command.ExecuteNonQuery();
					_ado.Connection.Close();
					return (Convert.ToBoolean(i),"");
				}
			});
		}
		catch (Exception ex)
		{
			return (false,ex.Message);
		}
	}
	public async Task<(bool,string)> DeleteRoleFromUserAsync(int roleId, int userId)
	{
		_ado.SqlQuery = "delete from UserRoles where user_id = @user_Id and role_id = @role_Id;";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@user_id", userId);
					_ado.Command.Parameters.AddWithValue("@role_id", roleId);
					_ado.Connection.Open();
					int i = _ado.Command.ExecuteNonQuery();
					_ado.Connection.Close();
					return (Convert.ToBoolean(i),"");
				}
			});
		}
		catch (Exception ex)
		{
			return (false,ex.Message);
		}
	}
}