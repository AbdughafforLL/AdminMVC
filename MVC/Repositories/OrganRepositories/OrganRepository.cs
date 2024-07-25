using MVC.Entities;
using MVC.Models;

namespace MVC.Repositories.OrganRepositories;
public class OrganRepository(IConfiguration configuration) : IOrganRepository
{
	private readonly SqlAdoModel _ado = new()
	{
		ConString = configuration.GetConnectionString("DefaultConnection")!
	};
	public async Task<(bool, string)> CreateOrganAsync(Organ model)
	{
		_ado.SqlQuery = "insert into Organs(organ_name)Values(@organ_name);";
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
					return (Convert.ToBoolean(i), "");
				}
			});
		}
		catch (Exception ex)
		{
			return (false, ex.Message);
		}
	}
	public async Task<(bool, string)> UpdateOrganAsync(Organ model)
	{
		_ado.SqlQuery = "update Organs set organ_name = @organ_name,updated_at = CONVERT(NVARCHAR(30),GETDATE(),120) where organ_id = @organ_id;";
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
					return (Convert.ToBoolean(i),"");
				}
			});
		}
		catch (Exception ex)
		{
			return (false, ex.Message);
		}
	}
	public async Task<(bool, string)> DeleteOrganAsync(int organId)
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
					return (Convert.ToBoolean(i), "");
				}
			});
		}
		catch (Exception ex)
		{
			return (false, ex.Message);
		}
	}
	public async Task<(string,Organ?)> GetOrganByIdAsync(int organId)
	{
		Organ organ = null!;
		_ado.SqlQuery = "select * from Organs where organ_id = @organ_id;";
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
					_ado.DataReader = _ado.Command.ExecuteReader();
					while (_ado.DataReader.Read())
					{
						organ = new Organ()
						{
							OrganId = (int)_ado.DataReader["organ_id"],
							OrganName = (string)_ado.DataReader["organ_name"],
							CreatedAt = (string)_ado.DataReader["created_at"],
							UpdatedAt = (string)_ado.DataReader["updated_at"]
						};
					}
					_ado.Connection.Close();
				}
				return ("", organ);
			});
		}
		catch (Exception ex)
		{
			return (ex.Message, organ);
		}
	}
	public async Task<(string,List<Organ>)> GetOrgansAsync()
	{
		List<Organ> organs = new();
		_ado.SqlQuery = "select * from Organs;";
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
						Organ organ = new()
						{
							OrganId = (int)_ado.DataReader["organ_id"],
							OrganName = (string)_ado.DataReader["organ_name"],
							CreatedAt = (string)_ado.DataReader["created_at"],
							UpdatedAt = (string)_ado.DataReader["updated_at"]
						};
						organs.Add(organ);
					}
					_ado.Connection.Close();
				}
				return ("",organs);
			});
		}
		catch (Exception ex)
		{
			return (ex.Message, organs);
		}
	}
}