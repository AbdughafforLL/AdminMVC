using MVC.Filters;
using MVC.Models.UserModels;
using MVC.Utils;
namespace MVC.Repositories.UserRepositories;

public class UserRepository : IUserRepository
{
	public async Task<(bool, string)> CreateUserAsync(CreateUserDto model,string hashPassword)
	{
		var parameters = new SqlParameter[] {
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
		var (res, message) = await SQL.ExecuteNonQueryAsync("UserInsert", parameters);
		
		return (res,message);
	}
	public async Task<(bool, string)> UpdateUserAsync(UpdateUserDto model)
	{
		var parameters = new SqlParameter[] {
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

		var (res,message) = await SQL.ExecuteNonQueryAsync("UserUpdate",parameters);
		return (res, message);
	}
	public async Task<(bool, string)> DeleteUserAsync(int userId)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@user_id", userId)
		};
		var (res,message) = await SQL.ExecuteNonQueryAsync("UserDelete",parameters);
		return (res, message);
	}
	public async Task<(string, GetUserByIdDto?)> GetUserByIdAsync(int userId)
	{
		var parameters = new SqlParameter[] { 
			new SqlParameter("@user_id", userId)
		};
		var (message,dataDet) = await SQL.ExecuteQueryDataSetAsync("UserGetById",parameters);


		var user = new GetUserByIdDto();
		return (message, user);
	}
	public async Task<(string, GetUserByIdDto?)> GetUserByUserNameAsync(string userName)
	{
		var parameters = new SqlParameter[] { 
			new SqlParameter("@user_name",userName)	
		};
		var(message,dataSet) = await SQL.ExecuteQueryDataSetAsync("UserGetByUserName", parameters);
		var user = new GetUserByIdDto();
		return (message,user);
	}
	public async Task<(string, List<GetUsersDto>)> GetUsersAsync(UserFilters model)
	{
		var parameters = new SqlParameter[] { 
			new SqlParameter("@page_number",model.PageNumber),
			new SqlParameter("@page_size",model.PageSize),
			new SqlParameter("@phone_number",model.PhoneNumber),
			new SqlParameter("@inn",model.Inn),
			new SqlParameter("@name",model.Name),
		};
		var (message, dataSet) = await SQL.ExecuteQueryDataSetAsync("UsersGet",parameters);
		var user = new List<GetUsersDto>();
		return (message,user);
	}
	public async Task<(string, List<int>)> GetRolesByUserIdAsync(int userId)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@user_id",userId)
		};
		var (message, dataTable) = await SQL.ExecuteQueryDataTableAsync("UserGetRolesById",parameters);
		var roles = new List<int>();
		return (message, roles);
	}
}