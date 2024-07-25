using MVC.Entities;
using MVC.Models;

namespace MVC.Repositories.StatusRepositories;
public class StatusRepository(IConfiguration configuration) : IStatusRepository
{
	private readonly SqlAdoModel _ado = new()
	{
		ConString = configuration.GetConnectionString("DefaultConnection")!
	};
	public async Task<(bool, string)> CreateStatusAsync(Status model)
	{
		_ado.SqlQuery = "insert into Statuses(status_name)Values(@status_name);";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@status_name", model.StatusName);
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
	public async Task<(bool, string)> UpdateStatusAsync(Status model)
	{
		_ado.SqlQuery = "update Statuses set status_name = @status_name,updated_at = GETDATE() where status_id = @status_id;";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@status_id", model.StatusId);
					_ado.Command.Parameters.AddWithValue("@status_name", model.StatusName);
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
	public async Task<(bool, string)> DeleteStatusAsync(int statusId)
	{
		_ado.SqlQuery = "delete from Statuses where status_id = @status_id;";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@status_id", statusId);
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
	public async Task<(string, Status?)> GetStatusByIdAsync(int statusId)
	{
		Status status = null!;
		_ado.SqlQuery = "select * from Statuses where status_id = @status_id;";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@status_id", statusId);
					_ado.Connection.Open();
					_ado.DataReader = _ado.Command.ExecuteReader();
					while (_ado.DataReader.Read())
					{
						status = new Status()
						{
							StatusId = (int)_ado.DataReader["status_id"],
							StatusName = (string)_ado.DataReader["status_name"],
							CreatedAt = (string)_ado.DataReader["created_at"],
							UpdatedAt = (string)_ado.DataReader["updated_at"]
						};
					}
					_ado.Connection.Close();
				}
				return ("", status);
			});
		}
		catch (Exception ex)
		{
			return (ex.Message, status);
		}
	}
	public async Task<(string, List<Status>)> GetStatusesAsync()
	{
		List<Status> statuses = new();
		_ado.SqlQuery = "select * from Statuses;";
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
						Status status = new()
						{
							StatusId = (int)_ado.DataReader["status_id"],
							StatusName = (string)_ado.DataReader["status_name"],
							CreatedAt = (string)_ado.DataReader["created_at"],
							UpdatedAt = (string)_ado.DataReader["updated_at"]
						};
						statuses.Add(status);
					}
					_ado.Connection.Close();
				}
				return ("", statuses);
			});
		}
		catch (Exception ex)
		{
			return (ex.Message, statuses);
		}
	}
}
