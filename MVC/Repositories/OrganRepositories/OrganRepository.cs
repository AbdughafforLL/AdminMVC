using MVC.Models.OrganModels;
using MVC.Utils;

namespace MVC.Repositories.OrganRepositories;
public class OrganRepository : IOrganRepository
{
	public async Task<(bool, string)> CreateOrganAsync(CreateOrganDto model)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",1),
			new SqlParameter("@organ_name",model.OrganName)
		};
		var (res, message) = await SQL.ExecuteNonQueryAsync("QueryOrgans", parameters);

		return (res, message);
	}
	public async Task<(bool, string)> UpdateOrganAsync(UpdateOrganDto model)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",2),
			new SqlParameter("@organ_id",model.OrganId),
			new SqlParameter("@organ_name",model.OrganName)
		};
		var (res, message) = await SQL.ExecuteNonQueryAsync("QueryOrgans", parameters);

		return (res, message);
	}
	public async Task<(bool, string)> DeleteOrganAsync(int organId)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",3),
			new SqlParameter("@organ_id",organId),
		};
		var (res, message) = await SQL.ExecuteNonQueryAsync("QueryOrgans", parameters);

		return (res, message);
	}
	public async Task<(string,GetOrganDto?)> GetOrganByIdAsync(int organId)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",4),
			new SqlParameter("@organ_id",organId)
		};

		var (res, dataTable) = await SQL.ExecuteQueryDataTableAsync("QueryAreas", parameters);

		var organ = new GetOrganDto() { OrganName = "" };
		return (res, organ);
	}
	public async Task<(string,List<GetOrganDto>)> GetOrgansAsync()
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",5),
		};

		var (res, dataTable) = await SQL.ExecuteQueryDataTableAsync("QueryAreas", parameters);
		var organs = new List<GetOrganDto>();
		return (res, organs);
	}
}