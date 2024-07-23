using MVC.Entities;
using MVC.Models;
using System.Data;
using System.Data.SqlClient;
namespace MVC.Repositories.RoleRepository;

public class RoleRepository(IConfiguration configuration) : IRoleRepository
{
	private readonly SqlAdoModel _ado = new()
	{
		ConString = configuration.GetConnectionString("DefaultConnection")!
	};

	public async Task<(bool,string)> CreateRole(Role model)
	{
		_ado.SqlQuery = "insert into Roles(role_name) Values (@roleName);";
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
					return (true,"");
				}
			});
		}
		catch (Exception ex)
		{
			return (false, ex.Message);
		}
	}
	public async Task<(bool,string,List<UserRole>)> GetRolesByUserId(string userId)
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
							RoleId = (string)_ado.DataReader["role_id"],
							UserId = (string)_ado.DataReader["user_id"]
						};
						roles.Add(role);
					}
					_ado.Connection.Close();
				}
				return (true,"",roles);
			});
		}
		catch (Exception ex)
		{
			return (false,ex.Message,roles);
		}
	}
	public async Task<(bool,string)> DeleteRole(string roleId)
	{
		_ado.SqlQuery = "delete from Roles where role_id = @roleId;";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.SqlQuery))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@roleId", roleId);

					_ado.Connection.Open();
					int i = _ado.Command.ExecuteNonQuery();
					_ado.Connection.Close();
					return (true,"");
				}
			});
		}
		catch (Exception ex)
		{
			return (false,ex.Message);
		}
	}
	public async Task<(string,Role?)> GetRoleById(string roleId)
	{
		Role role = null!;
		_ado.SqlQuery = "select * from Roles where role_id = @roleId;";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@roleId", roleId);

					_ado.Connection.Open();
					_ado.DataReader = _ado.Command.ExecuteReader();
					while (_ado.DataReader.Read())
					{
						role = new Role()
						{
							RoleId = (string)_ado.DataReader["role_id"],
							RoleName = (string)_ado.DataReader["role_name"],
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
	public async Task<(string,List<Role>)> GetRoles()
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
							RoleId = (string)_ado.DataReader["role_id"],
							RoleName = (string)_ado.DataReader["role_name"],
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
	public async Task<(bool,string)> UpdateRole(Role model)
	{
		_ado.SqlQuery = "update from Roles set role_name = @roleName where role_id = @roleId;";
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
					return (true, "");
				}
			});
		}
		catch (Exception ex)
		{
			return (false,ex.Message);
		}
	}
	public async Task<(bool,string)> AddRoleToUser(string roleId, string userId)
	{
		_ado.SqlQuery = "insert into UserRoles(user_id,role_id)Values(@user_id,@role_id);";
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
	public async Task<(bool,string)> DeleteRoleInUser(string roleId, string userId)
	{
		_ado.SqlQuery = "delete from UserRoles where user_id = @user_Id and role_id=@role_Id;";
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