using MVC.Filters;
using MVC.Models.UserModels;
using MVC.Utils;
namespace MVC.Repositories.UserRepositories;

public class UserRepository : IUserRepository
{
	public async Task<(bool, string)> CreateUserAsync(CreateUserDto model,string hashPassword)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",1),
			new SqlParameter("@user_name", model.UserName),
			new SqlParameter("@ips", model.Ips),
			new SqlParameter("@inn", model.Inn),
			new SqlParameter("@first_name", model.FirstName),
			new SqlParameter("@last_name", model.LastName),
			new SqlParameter("@middle_name", model.MiddleName),
			new SqlParameter("@adr_text", model.AdrText),
			new SqlParameter("@adr_email", model.AdrEmail),
			new SqlParameter("@adr_website", model.AdrWebSite),
			new SqlParameter("@phone_number", model.PhoneNumber),
			new SqlParameter("@organ_id", model.OrganId),
			new SqlParameter("@status_id", model.ProfessionId),
			new SqlParameter("@hash_password", hashPassword),
			new SqlParameter("@created_user_id", model.CreatedUserId)
		};
		var (res, message) = await SQL.ExecuteNonQueryAsync("QueryUsers", parameters);
		
		return (res,message);
	}
	public async Task<(bool, string)> UpdateUserAsync(UpdateUserDto model)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id", 2),
			new SqlParameter("@user_id", model.UserId),
			new SqlParameter("@user_name", model.UserName),
			new SqlParameter("@ips", model.Ips),
			new SqlParameter("@inn", model.Inn),
			new SqlParameter("@first_name", model.FirstName),
			new SqlParameter("@last_name", model.LastName),
			new SqlParameter("@middle_name", model.MiddleName),
			new SqlParameter("@adr_text", model.AdrText),
			new SqlParameter("@adr_email", model.AdrEmail),
			new SqlParameter("@adr_website", model.AdrWebSite),
			new SqlParameter("@phone_number", model.PhoneNumber),
			new SqlParameter("@organ_id", model.OrganId),
			new SqlParameter("@status_id", model.ProfessionId)
		};

		var (res,message) = await SQL.ExecuteNonQueryAsync("QueryUsers",parameters);
		return (res, message);
	}
	public async Task<(string, DataTable)> DeleteUserAsync(int userId)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",3),
			new SqlParameter("@user_id", userId)
		};
		var (message,dt) = await SQL.ExecuteQueryDataTableAsync("QueryUsers",parameters);
		return (message,dt!);
	}
	public async Task<(string, DataSet?)> GetUserByIdAsync(int userId)
	{
		var parameters = new SqlParameter[] { 
			new SqlParameter("@query_id", 4),
			new SqlParameter("@user_id", userId)
		};
		var (message,ds) = await SQL.ExecuteQueryDataSetAsync("QueryUsers",parameters);
		return (message, ds);
	}
	public async Task<(string, DataSet?)> GetUserByUserNameAsync(string userName)
	{
		var parameters = new SqlParameter[] { 
			new SqlParameter("@query_id",6),
			new SqlParameter("@user_name",userName)
		};
		var(message,ds) = await SQL.ExecuteQueryDataSetAsync("QueryUsers", parameters);
		return (message,ds);
	}
	public async Task<(string, DataSet?)> GetUsersAsync(UserFilters model)
	{
		var parameters = new SqlParameter[] { 
			new SqlParameter("@query_id",5),
			new SqlParameter("@page_number",model.PageNumber),
			new SqlParameter("@page_size",model.PageSize),
			new SqlParameter("@inn_f",$"%{model.Inn}%"),
			new SqlParameter("@name_f",$"%{model.Name}%"),
		};
		var (message, ds) = await SQL.ExecuteQueryDataSetAsync("QueryUsers",parameters);
		return (message,ds);
	}
	public async Task<(string, DataTable?)> GetRolesByUserIdAsync(int userId)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",7),
			new SqlParameter("@user_id",userId)
		};
		var (message, dt) = await SQL.ExecuteQueryDataTableAsync("QueryUsers",parameters);
		return (message, dt);
	}
}