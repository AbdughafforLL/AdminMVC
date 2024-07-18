using System.Data;
using System.Data.SqlClient;
using MVC.Entities;
using MVC.Models;
namespace MVC.Repositories.UserRepositories;

public class UserRepository(IConfiguration configuration) : IUserRepository
{
    private readonly SqlAdoModel _ado = new ();
    
    public async Task<bool> CreateUser(User model)
    {
        _ado.SqlQuery = "insert into Users(user_id,user_name,hash_password,email,phone_number,organ_id) " +
                     "Values (@user_id,@user_name,@hash_password,@email,@phone_number,@organ_id);";
        _ado.ConString = configuration.GetConnectionString("DefaultConnection")!;
        try
        {
            return await Task.Run(() =>
            {
                using (_ado.Connection = new SqlConnection(_ado.ConString))
                {
                    _ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
                    _ado.Command.CommandType = CommandType.Text;
                    _ado.Command.Parameters.AddWithValue("@user_id", model.UserId);
                    _ado.Command.Parameters.AddWithValue("@user_name", model.UserName);
                    _ado.Command.Parameters.AddWithValue("@hash_password", model.HashPassword);
                    _ado.Command.Parameters.AddWithValue("@email", model.Email ?? string.Empty);
                    _ado.Command.Parameters.AddWithValue("@phone_number", model.PhoneNumber ?? string.Empty);
                    _ado.Command.Parameters.AddWithValue("@organ_id", model.OrganId);
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
    public async Task<bool> UpdateUser(User model)
    {
        _ado.SqlQuery = "update Users set user_name = @user_name,email = @email,phone_number=@phone_number," +
                        "organ_id = @organ_id where user_id = @user_id;";
        _ado.ConString = configuration.GetConnectionString("DefaultConnection")!;
        try
        {
            return await Task.Run(() =>
            {
                using (_ado.Connection = new SqlConnection(_ado.ConString))
                {
                    _ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
                    _ado.Command.CommandType = CommandType.Text;
                    _ado.Command.Parameters.AddWithValue("@user_id", model.UserId);
                    _ado.Command.Parameters.AddWithValue("@user_name", model.UserName);
                    _ado.Command.Parameters.AddWithValue("@email", model.Email ?? string.Empty);
                    _ado.Command.Parameters.AddWithValue("@phone_number", model.PhoneNumber ?? string.Empty);
                    _ado.Command.Parameters.AddWithValue("@organ_id", model.OrganId);
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
    public async Task<bool> DeleteUser(string userId)
    {
        _ado.SqlQuery = "delete from Users where user_id = @user_id;";
        _ado.ConString = configuration.GetConnectionString("DefaultConnection")!;
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
    public async Task<User> GetUserById(string userId)
    {
        User user = null!;
        _ado.SqlQuery = "select * from Users where user_id = @user_id;";
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
                        user = new User()
                        {
                            UserId = (string)_ado.DataReader["user_id"],
                            UserName = (string)_ado.DataReader["user_name"],
                            HashPassword = (string)_ado.DataReader["hash_password"],
                            Email = (string)_ado.DataReader["email"] ?? string.Empty,
                            PhoneNumber = (string)_ado.DataReader["phone_number"] ?? string.Empty,
                            OrganId = (string)_ado.DataReader["organ_id"]
                        };
                    }
                    _ado.Connection.Close();
                }
                return user;
            });
        }
        catch (Exception)
        {
            return user;
        }
    }
    public async Task<User> GetUserByUserName(string userName)
    {
        User user = null!;
        _ado.SqlQuery = "select * from Users where user_name = @user_name;";
        _ado.ConString = configuration.GetConnectionString("DefaultConnection")!;
        try
        {
            return await Task.Run(() => {
                using (_ado.Connection = new SqlConnection(_ado.ConString))
                {
                    _ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
                    _ado.Command.CommandType = CommandType.Text;
                    _ado.Command.Parameters.AddWithValue("@user_name", userName);
                    _ado.Connection.Open();
                    _ado.DataReader = _ado.Command.ExecuteReader();
                    while (_ado.DataReader.Read())
                    {
                        user = new User()
                        {
                            UserId = (string)_ado.DataReader["user_id"],
                            UserName = (string)_ado.DataReader["user_name"],
                            HashPassword = (string)_ado.DataReader["hash_password"],
                            Email = (string)_ado.DataReader["email"],
                            PhoneNumber = (string)_ado.DataReader["phone_number"],
                            OrganId = (string)_ado.DataReader["organ_id"]
                        };
                    }
                    _ado.Connection.Close();
                }
                return user;
            });
        }
        catch (Exception)
        {
            return user;
        }
    }
    public async Task<List<User>> GetUsers()
    {
        List<User> users = new();
        _ado.SqlQuery = "select * from Users;";
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
                        User user = new ()
                        {
                            UserId = (string)_ado.DataReader["user_id"],
                            UserName = (string)_ado.DataReader["user_name"],
                            HashPassword = (string)_ado.DataReader["hash_password"],
                            Email = (string)_ado.DataReader["email"] ?? string.Empty,
                            PhoneNumber = (string)_ado.DataReader["phone_number"] ?? string.Empty,
                            OrganId = (string)_ado.DataReader["organ_id"]
                        };
                        users.Add(user);
                    }
                    _ado.Connection.Close();
                }
                return users;
            });
        }
        catch (Exception)
        {
            return users;
        }
    }
}