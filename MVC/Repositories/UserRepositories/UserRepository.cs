using MVC.Entities;
using MVC.Filters;
using MVC.Models;
namespace MVC.Repositories.UserRepositories;

public class UserRepository(IConfiguration configuration) : IUserRepository
{
	private readonly SqlAdoModel _ado = new()
	{
		ConString = configuration.GetConnectionString("DefaultConnection")!
	};
	public async Task<(bool, string)> CreateUserAsync(User model)
	{
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand("UserInsert", _ado.Connection);
					_ado.Command.CommandType = CommandType.StoredProcedure;
					_ado.Command.Parameters.AddWithValue("@user_name", model.UserName);
					_ado.Command.Parameters.AddWithValue("@ips", model.Ips);
					_ado.Command.Parameters.AddWithValue("@inn", model.Inn);
					_ado.Command.Parameters.AddWithValue("@first_name", model.FirstName);
					_ado.Command.Parameters.AddWithValue("@last_name", model.LastName);
					_ado.Command.Parameters.AddWithValue("@middle_name", model.MiddleName);
					_ado.Command.Parameters.AddWithValue("@adr_text", model.AdrText);
					_ado.Command.Parameters.AddWithValue("@adr_email", model.AdrEmail);
					_ado.Command.Parameters.AddWithValue("@adr_website", model.AdrWebSite);
					_ado.Command.Parameters.AddWithValue("@phone_number", model.PhoneNumber);
					_ado.Command.Parameters.AddWithValue("@organ_id", model.OrganId);
					_ado.Command.Parameters.AddWithValue("@status_id", model.StatusId);
					_ado.Command.Parameters.AddWithValue("@hash_password", model.HashPassword);
					_ado.Command.Parameters.AddWithValue("@created_user_id", model.CreatedUserId);
					_ado.Connection.Open();
					int status_code=0;
					using (_ado.DataReader = _ado.Command.ExecuteReader())
					{
						while (_ado.DataReader.Read())
						{
							status_code = (int)_ado.DataReader["status_code"];
						}
					}
					_ado.Connection.Close();
					return status_code == 0 ? (false, "error db") : (true, "");
				}
			});
		}
		catch (Exception ex)
		{
			return (false, ex.Message);
		}
	}
	public async Task<(bool, string)> UpdateUserAsync(User model)
	{
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
					_ado.Command.Parameters.AddWithValue("@ips", model.Ips);
					_ado.Command.Parameters.AddWithValue("@inn", model.Inn);
					_ado.Command.Parameters.AddWithValue("@first_name", model.FirstName);
					_ado.Command.Parameters.AddWithValue("@last_name", model.LastName);
					_ado.Command.Parameters.AddWithValue("@middle_name", model.MiddleName);
					_ado.Command.Parameters.AddWithValue("@adr_text", model.AdrText);
					_ado.Command.Parameters.AddWithValue("@adr_email", model.AdrEmail);
					_ado.Command.Parameters.AddWithValue("@adr_website", model.AdrWebSite);
					_ado.Command.Parameters.AddWithValue("@phone_number", model.PhoneNumber);
					_ado.Command.Parameters.AddWithValue("@organ_id", model.OrganId);
					_ado.Command.Parameters.AddWithValue("@status_id", model.StatusId);
					_ado.Connection.Open();
					int status_code = 0;
					using (_ado.DataReader = _ado.Command.ExecuteReader())
					{
						while (_ado.DataReader.Read())
						{
							status_code = (int)_ado.DataReader["status_id"];
						}
					}
					_ado.Connection.Close();
					return status_code == 0 ? (false, "error") : (true, "");
				}
			});
		}
		catch (Exception ex)
		{
			return (false, ex.Message); ;
		}
	}
	public async Task<(bool, string)> DeleteUserAsync(int userId)
	{
		_ado.SqlQuery = "delete from Users where user_id=@user_id;";
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
					var res = _ado.Command.ExecuteNonQuery();
					_ado.Connection.Close();
				}
				return (true, "");
			});
		}
		catch (Exception ex)
		{
			return (false, ex.Message);
		}
	}
	public async Task<(string, User?)> GetUserByIdAsync(int userId)
	{
		User user = null!;
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand("UserGetById", _ado.Connection);
					_ado.Command.CommandType = CommandType.StoredProcedure;
					_ado.Command.Parameters.AddWithValue("@user_id", userId);
					_ado.Connection.Open();
					using (_ado.DataReader = _ado.Command.ExecuteReader())
					{
						while (_ado.DataReader.Read())
						{
							user = new()
							{
								UserId = (int)_ado.DataReader["user_id"],
								UserName = (string)_ado.DataReader["user_name"],
								Ips = (string)_ado.DataReader["ips"],
								Inn = (string)_ado.DataReader["inn"],
								FirstName = (string)_ado.DataReader["first_name"],
								LastName = (string)_ado.DataReader["last_name"],
								MiddleName = (string)_ado.DataReader["middle_name"],
								PhoneNumber = (string)_ado.DataReader["phone_number"],
								AdrText = (string)_ado.DataReader["adr_text"],
								AdrEmail = (string)_ado.DataReader["adr_email"],
								AdrWebSite = (string)_ado.DataReader["adr_website"],
								StatusId = (int)_ado.DataReader["status_name"],
								CreatedUserId = (int)_ado.DataReader["created_user"],
								OrganId = (int)_ado.DataReader["organ_name"],
								CreatedAt = (string)_ado.DataReader["created_at"],
								UpdatedAt = (string)_ado.DataReader["updated_at"]
							};
						}
						_ado.Connection.Close();
					}
				}
				return ("", user);
			});
		}
		catch (Exception ex)
		{
			return (ex.Message, user);
		}
	}
	public async Task<(string, User?)> GetUserByUserNameAsync(string userName)
	{
		User user = null!;
		_ado.SqlQuery = "select * from Users where user_name = @user_name;";
		try
		{
			return await Task.Run(() =>
			{
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
							UserId = (int)_ado.DataReader["user_id"],
							UserName = (string)_ado.DataReader["user_name"],
							Ips = (string)_ado.DataReader["ips"],
							Inn = (string)_ado.DataReader["inn"],
							FirstName = (string)_ado.DataReader["first_name"],
							LastName = (string)_ado.DataReader["last_name"],
							MiddleName = (string)_ado.DataReader["middle_name"],
							FullName = (string)_ado.DataReader["full_name"],
							AdrText = (string)_ado.DataReader["adr_text"],
							AdrEmail = (string)_ado.DataReader["adr_email"],
							AdrWebSite = (string)_ado.DataReader["adr_website"],
							CreatedAt = (string)_ado.DataReader["created_at"],
							UpdatedAt = (string)_ado.DataReader["updated_at"],
							OrganId = (int)_ado.DataReader["organ_id"],
							StatusId = (int)_ado.DataReader["status_id"],
							CreatedUserId = (int)_ado.DataReader["created_user_id"],
							PhoneNumber = (string)_ado.DataReader["phone_number"],
							HashPassword = (string)_ado.DataReader["hash_password"],
						};
					}
					_ado.Connection.Close();
				}
				return ("", user);
			});
		}
		catch (Exception ex)
		{
			return (ex.Message, user);
		}

	}
	public async Task<(string, List<User>)> GetUsersAsync(UserFilters model)
	{
		List<User> users = new();
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand("UsersGet", _ado.Connection);
					_ado.Command.CommandType = CommandType.StoredProcedure;
					_ado.Command.Parameters.AddWithValue("@page_number", model.PageNumber);
					_ado.Command.Parameters.AddWithValue("@page_size", model.PageSize);
					_ado.Command.Parameters.AddWithValue("@phone_number", model.PhoneNumber);
					_ado.Command.Parameters.AddWithValue("@inn", model.Inn);
					_ado.Command.Parameters.AddWithValue("@name", model.Name);

					_ado.Connection.Open();
					_ado.DataReader = _ado.Command.ExecuteReader();
					while (_ado.DataReader.Read())
					{
						User user = new()
						{
							UserId = (int)_ado.DataReader["user_id"],
							UserName = (string)_ado.DataReader["user_name"],
							Ips = (string)_ado.DataReader["ips"],
							Inn = (string)_ado.DataReader["inn"],
							FirstName = (string)_ado.DataReader["first_name"],
							LastName = (string)_ado.DataReader["last_name"],
							MiddleName = (string)_ado.DataReader["middle_name"],
							FullName = (string)_ado.DataReader["full_name"],
							PhoneNumber = (string)_ado.DataReader["phone_number"],
							AdrText = (string)_ado.DataReader["adr_text"],
							AdrEmail = (string)_ado.DataReader["adr_email"],
							AdrWebSite = (string)_ado.DataReader["adr_website"],
							StatusId = (int)_ado.DataReader["status_id"],
							CreatedUserId = (int)_ado.DataReader["created_user_id"],
							OrganId = (int)_ado.DataReader["organ_id"],
							CreatedAt = (string)_ado.DataReader["created_at"],
							UpdatedAt = (string)_ado.DataReader["updated_at"]
						};
						users.Add(user);
					}
					_ado.Connection.Close();
				}
				return ("", users);
			});
		}
		catch (Exception ex)
		{
			return (ex.Message, users);
		}
	}
	public async Task<(string, List<int>)> GetRolesByUserIdAsync(int userId)
	{
		_ado.SqlQuery = "select role_id from UserRoles where user_id = @user_id union select role_id from StatusRoles where status_id = (select status_id from Users where user_id = @user_id)";
		List<int> roles = new();
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@user_id",userId);

					_ado.Connection.Open();
					_ado.DataReader = _ado.Command.ExecuteReader();
					while (_ado.DataReader.Read())
					{
						roles.Add((int)_ado.DataReader["role_id"]);
					}
					_ado.Connection.Close();
				}
				return ("", roles);
			});
		}
		catch (Exception ex)
		{
			return (ex.Message, roles);
		}
	}
}