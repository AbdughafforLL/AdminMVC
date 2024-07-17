using System.Data;
using System.Data.SqlClient;
using MVC.Entities;
using MVC.Models;

namespace MVC.Repositories.RoleRepository;

public class RoleRepository(IConfiguration configuration) : IRoleRepository
{
    private readonly SqlAdoModel _ado = new ();
    
    public async Task<bool> CreateRole(Role model)
    {
        _ado.SqlQuery = "insert into Roles(role_name) Values (@roleName)";
        _ado.ConString = configuration.GetConnectionString("DefaultConnection")!;
        try
        {
            return await Task.Run(() =>
            {
                using (_ado.Connection = new SqlConnection(_ado.ConString))
                {
                    _ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
                    _ado.Command.CommandType = CommandType.Text;
                    _ado.Command.Parameters.AddWithValue("@roleName", model.RoleName);
                    _ado.Connection.Open();
                    int i = _ado.Command.ExecuteNonQuery();
                    _ado.Connection.Close();
                    return Convert.ToBoolean(i);
                }
            });
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<List<UserRole>> GetRolesByUserId(string userId)
    {
        List<UserRole> roles = null!;
        _ado.SqlQuery = "select * from UserRoles where user_id = @user_id;";
        _ado.ConString = configuration.GetConnectionString("DefaultConnection")!;
        try
        {
            return await Task.Run(() => {
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
                return roles;
            });
        }
        catch (Exception)
        {
            return roles;
        }
    }

    public async Task<bool> DeleteRole(string roleId)
    {
        _ado.SqlQuery = "delete from Roles where role_id = @roleId;";
        _ado.ConString = configuration.GetConnectionString("DefaultConnection")!;
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
                    return Convert.ToBoolean(i);
                }
            });
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<Role> GetRoleById(string roleId)
    {
        Role role = null!;
        _ado.SqlQuery = "select * from Roles where role_id = @roleId;";
        _ado.ConString = configuration.GetConnectionString("DefaultConnection")!;
        try
        {
            return await Task.Run(() => {
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
                return role;
            });
        }
        catch (Exception)
        {
            return role;
        }
    }

    public async Task<List<Role>> GetRoles()
    {
        var roles = new List<Role>();
        _ado.SqlQuery = "select * from dbo.Roles;";
        _ado.ConString = configuration.GetConnectionString("DefaultConnection")!;
        try
        {
            return await Task.Run(() => {
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
                return roles;
            });
        }
        catch (Exception)
        {
            return roles;
        }
    }

    public async Task<bool> UpdateRole(Role model)
    {
        _ado.SqlQuery = "update from dbo.Roles set role_name = @roleName where role_id = @roleId;";
        _ado.ConString = configuration.GetConnectionString("DefaultConnection")!;
        try
        {
            return await Task.Run(() => {
                using (_ado.Connection = new SqlConnection(_ado.ConString))
                {
                    _ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
                    _ado.Command.CommandType = CommandType.Text;
                    _ado.Command.Parameters.AddWithValue("@role_name",model.RoleName);
                    _ado.Command.Parameters.AddWithValue("@role_id",model.RoleId);
                    
                    _ado.Connection.Open();
                    int i = _ado.Command.ExecuteNonQuery();
                    _ado.Connection.Close();
                    return Convert.ToBoolean(i);
                }
            });
        }
        catch (Exception)
        {
            return false;
        }
    }

    public Task<bool> AddRoleToUser()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteRoleInUser()
    {
        throw new NotImplementedException();
    }
}