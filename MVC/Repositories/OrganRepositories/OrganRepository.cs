using MVC.Filters;
using MVC.Models.OrganModels;
using MVC.Utils;

namespace MVC.Repositories.OrganRepositories;
public class OrganRepository : IOrganRepository
{
	public async Task<(string,DataTable)> CreateOrganAsync(CreateOrganDto model)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",1),
			new SqlParameter("@organ_name",model.OrganName)
		};
		var (message,dt) = await SQL.ExecuteQueryDataTableAsync("QueryOrgans", parameters);
		return (message,dt!);
	}
	public async Task<(string,DataTable)> UpdateOrganAsync(UpdateOrganDto model)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",2),
			new SqlParameter("@organ_id",model.OrganId),
			new SqlParameter("@organ_name",model.OrganName)
		};
		var (message, dt) = await SQL.ExecuteQueryDataTableAsync("QueryOrgans", parameters);
		return (message,dt!);
	}
	public async Task<(string,DataTable)> DeleteOrganAsync(int organId)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",3),
			new SqlParameter("@organ_id",organId),
		};
		var (message,dt) = await SQL.ExecuteQueryDataTableAsync("QueryOrgans", parameters);
		return (message,dt!);
	}
	public async Task<(string,DataTable?)> GetOrganByIdAsync(int organId)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",4),
			new SqlParameter("@organ_id",organId)
		};
		var (res, dt) = await SQL.ExecuteQueryDataTableAsync("QueryOrgans", parameters);
		return (res, dt);
	}
	public async Task<(string,DataSet?)> GetOrgansWithFilterAsync(OrganFilter model)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",6),
			new SqlParameter("@page_number",model.PageNumber),
			new SqlParameter("@page_size",model.PageSize),
			new SqlParameter("@organ_name_f",$"%{model.OrganName}%"),
		};
		var (res, ds) = await SQL.ExecuteQueryDataSetAsync("QueryOrgans", parameters);
		return (res, ds);
	}
	public async Task<(string, DataTable?)> GetOrgansAsync()
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",5)
		};
		var (res, dt) = await SQL.ExecuteQueryDataTableAsync("QueryOrgans", parameters);
		return (res, dt);
	}
}