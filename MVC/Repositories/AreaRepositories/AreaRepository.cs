using MVC.Models.AreaModels;
using MVC.Utils;

namespace MVC.Repositories.AreaRepositories;
public class AreaRepository : IAreaRepository
{
	public async Task<(bool, string)> CreateAreaAsync(CreateAreaDto model)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",1),
			new SqlParameter("@area_name",model.AreaName)
		};
		var (res, message) = await SQL.ExecuteNonQueryAsync("QueryAreas",parameters);
		
		return (res, message);
	}
	public async Task<(bool, string)> UpdateAreaAsync(UpdateAreaDto model)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",2),
			new SqlParameter("@area_id",model.AreaId),
			new SqlParameter("@area_name",model.AreaName),
		};

		var (res, message) = await SQL.ExecuteNonQueryAsync("QueryAreas",parameters);
		return (res, message);
	}
	public async Task<(bool, string)> DeleteAreaAsync(int areaId)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",3),
			new SqlParameter("@area_id",areaId)
		};

		var (res, message) = await SQL.ExecuteNonQueryAsync("QueryAreas", parameters);
		return (res, message);
	}
	public async Task<(string, DataTable?)> GetAreaByIdAsync(int areaId)
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",4),
			new SqlParameter("@area_id",areaId)
		};

		var (res, dataTable) = await SQL.ExecuteQueryDataTableAsync("QueryAreas", parameters);
		return (res, dataTable);
	}
	public async Task<(string, DataTable?)> GetAreasAsync()
	{
		var parameters = new SqlParameter[] {
			new SqlParameter("@query_id",5)
		};

		var (res, dataTable) = await SQL.ExecuteQueryDataTableAsync("QueryAreas", parameters);
		return (res, dataTable);
	}
}