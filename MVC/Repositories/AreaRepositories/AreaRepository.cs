using MVC.Entities;
using MVC.Models;

namespace MVC.Repositories.AreaRepositories;
public class AreaRepository(IConfiguration configuration) : IAreaRepository
{
	private readonly SqlAdoModel _ado = new()
	{
		ConString = configuration.GetConnectionString("DefaultConnection")!
	};
	public async Task<(bool, string)> CreateAreaAsync(Area model)
	{
		_ado.SqlQuery = "insert into Areas(area_name)Values(@area_name);";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@area_name", model.AreaName);
					_ado.Connection.Open();
					int i = _ado.Command.ExecuteNonQuery();
					_ado.Connection.Close();
					return (Convert.ToBoolean(i), "");
				}
			});
		}
		catch (Exception ex)
		{
			return (false, ex.Message);
		}
	}
	public async Task<(bool, string)> UpdateAreaAsync(Area model)
	{
		_ado.SqlQuery = "update Areas set area_name = @area_name,updated_at = GETDATE() where area_id = @area_id;";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@area_id", model.AreaId);
					_ado.Command.Parameters.AddWithValue("@area_name", model.AreaName);
					_ado.Connection.Open();
					int i = _ado.Command.ExecuteNonQuery();
					_ado.Connection.Close();
					return (Convert.ToBoolean(i), "");
				}
			});
		}
		catch (Exception ex)
		{
			return (false, ex.Message);
		}
	}
	public async Task<(bool, string)> DeleteAreaAsync(int areaId)
	{
		_ado.SqlQuery = "delete from Areas where area_id = @area_id;";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@area_id", areaId);
					_ado.Connection.Open();
					int i = _ado.Command.ExecuteNonQuery();
					_ado.Connection.Close();
					return (Convert.ToBoolean(i), "");
				}
			});
		}
		catch (Exception ex)
		{
			return (false, ex.Message);
		}
	}
	public async Task<(string, Area?)> GetAreaByIdAsync(int areaId)
	{
		Area area = null!;
		_ado.SqlQuery = "select * from Areas where area_id = @area_id;";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@area_id", areaId);
					_ado.Connection.Open();
					_ado.DataReader = _ado.Command.ExecuteReader();
					while (_ado.DataReader.Read())
					{
						area = new Area()
						{
							AreaId = (int)_ado.DataReader["area_id"],
							AreaName = (string)_ado.DataReader["area_name"],
							CreatedAt = (string)_ado.DataReader["created_at"],
							UpdatedAt = (string)_ado.DataReader["updated_at"]
						};
					}
					_ado.Connection.Close();
				}
				return ("", area);
			});
		}
		catch (Exception ex)
		{
			return (ex.Message, area);
		}
	}
	public async Task<(string, List<Area>)> GetAreasAsync()
	{
		List<Area> areas = new();
		_ado.SqlQuery = "select * from Areas;";
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
						Area area = new()
						{
							AreaId = (int)_ado.DataReader["area_id"],
							AreaName = (string)_ado.DataReader["area_name"],
							CreatedAt = (string)_ado.DataReader["created_at"],
							UpdatedAt = (string)_ado.DataReader["updated_at"]
						};
						areas.Add(area);
					}
					_ado.Connection.Close();
				}
				return ("", areas);
			});
		}
		catch (Exception ex)
		{
			return (ex.Message, areas);
		}
	}
}