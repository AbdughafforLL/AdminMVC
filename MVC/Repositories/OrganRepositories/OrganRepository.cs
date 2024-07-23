using MVC.Entities;
using MVC.Models;
using System.Data;
using System.Data.SqlClient;

namespace MVC.Repositories.OrganRepositories;
public class OrganRepository(IConfiguration configuration) : IOrganRepository
{
	private readonly SqlAdoModel _ado = new()
	{
		ConString = configuration.GetConnectionString("DefaultConnection")!
	};
	public async Task<(bool, string)> CreateOrgan(Organ model)
	{
		_ado.SqlQuery = "insert into Organs(organ_name)Values (@organ_name);";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@organ_name", model.OrganName);
					_ado.Connection.Open();
					int i = _ado.Command.ExecuteNonQuery();
					_ado.Connection.Close();
					return (true, "");
				}
			});
		}
		catch (Exception ex)
		{
			return (false, ex.Message);
		}
	}
	public async Task<(bool, string)> UpdateOrgan(Organ model)
	{
		_ado.SqlQuery = "update Organs set organ_name = @organ_name,updated_at = GETDATE() where organ_id = @organ_id;";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@organ_id", model.OrganId);
					_ado.Command.Parameters.AddWithValue("@organ_name", model.OrganName);
					_ado.Connection.Open();
					int i = _ado.Command.ExecuteNonQuery();
					_ado.Connection.Close();
					return (true, "");
				}
			});
		}
		catch (Exception ex)
		{
			return (false, ex.Message);
		}
	}
	public async Task<(bool, string)> DeleteOrgan(int organId)
	{
		_ado.SqlQuery = "delete from Organs where organ_id = @organ_id;";
		try
		{
			return await Task.Run(() =>
			{
				using (_ado.Connection = new SqlConnection(_ado.ConString))
				{
					_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
					_ado.Command.CommandType = CommandType.Text;
					_ado.Command.Parameters.AddWithValue("@organ_id", organId);
					_ado.Connection.Open();
					int i = _ado.Command.ExecuteNonQuery();
					_ado.Connection.Close();
					return (true, "");
				}
			});
		}
		catch (Exception ex)
		{
			return (false, ex.Message);
		}
	}
	public async Task<Organ> GetOrganById(int organId)
	{
		Organ organ = null!;
		_ado.SqlQuery = "select * from Organs where organ_id = @organ_id;";
		return await Task.Run(() =>
		{
			using (_ado.Connection = new SqlConnection(_ado.ConString))
			{
				_ado.Command = new SqlCommand(_ado.SqlQuery, _ado.Connection);
				_ado.Command.CommandType = CommandType.Text;
				_ado.Command.Parameters.AddWithValue("@organ_id", organId);
				_ado.Connection.Open();
				_ado.DataReader = _ado.Command.ExecuteReader();
				while (_ado.DataReader.Read())
				{
					organ = new Organ()
					{
						OrganId = (int)_ado.DataReader["organ_id"],
						OrganName = (string)_ado.DataReader["organ_name"],
						CreatedAt = _ado.DataReader["created_at"].ToString(),
						UpdatedAt = _ado.DataReader["updated_at"].ToString()
					};
				}
				_ado.Connection.Close();
			}
			return organ;
		});
	}
	public async Task<List<Organ>> GetOrgans()
	{
		List<Organ> organs = new();
		_ado.SqlQuery = "select * from Organs;";
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
					Organ organ = new()
					{
						OrganId = (int)_ado.DataReader["organ_id"],
						OrganName = (string)_ado.DataReader["organ_name"],
						CreatedAt = _ado.DataReader["created_at"].ToString(),
						UpdatedAt = _ado.DataReader["updated_at"].ToString()
					};
					organs.Add(organ);
				}
				_ado.Connection.Close();
			}
			return organs;
		});
	}
}