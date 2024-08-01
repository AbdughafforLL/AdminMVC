using MVC.Models.StatusModels;
using MVC.Utils;

namespace MVC.Repositories.StatusRepositories;
public class ProfessionRepository : IProfessionRepository
{
	public async Task<(bool, string)> CreateProfessionAsync(CreateProfessionDto model)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",1),
			new SqlParameter("@profession_name",model.ProfessionName)
		};

		var (res, message) = await SQL.ExecuteNonQueryAsync("QueryProfessions", parameters);
		return (res, message);
	}
	public async Task<(bool, string)> UpdateProfessionAsync(UpdateProfessionDto model)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",2),
			new SqlParameter("@profession_name",model.ProfessionName),
			new SqlParameter("@profession_id",model.ProfessionId)
		};

		var (res, message) = await SQL.ExecuteNonQueryAsync("QueryProfessions", parameters);
		return (res, message);
	}
	public async Task<(bool, string)> DeleteProfessionAsync(int professionId)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",3),
			new SqlParameter("@profession_id",professionId)
		};
		var (res, message) = await SQL.ExecuteNonQueryAsync("QueryProfessions", parameters);
		return (res, message);
	}
	public async Task<(string, DataTable?)> GetProfessionByIdAsync(int professionId)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",4),
			new SqlParameter("@profession_id",professionId)
		};
		var (message, dt) = await SQL.ExecuteQueryDataTableAsync("QueryProfessions", parameters);
		return (message, dt);
	}
	public async Task<(string, DataTable?)> GetProfessionsAsync()
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",5),
		};
		var (message, dt) = await SQL.ExecuteQueryDataTableAsync("QueryProfessions", parameters);
		return (message, dt);
	}
}