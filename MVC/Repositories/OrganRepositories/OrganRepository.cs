using MVC.Entities;
using MVC.Models;
using System.Data.SqlClient;
using System.Data;

namespace MVC.Repositories.OrganRepositories;
public class OrganRepository(IConfiguration configuration) : IOrganRepository
{
    private readonly SqlAdoModel _ado = new()
    {
        ConString = configuration.GetConnectionString("DefaultConnection")!
    };
    public async Task<bool> CreateOrgan(Organ model)
    {
        _ado.SqlQuery = "insert into Organs(organ_id,organ_name)Values (@organ_id,@organ_name);";
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
                    return Convert.ToBoolean(i);
                }
            });
        }
        catch (Exception)
        {
            return false;
        }
    }
    public async Task<bool> UpdateOrgan(Organ model)
    {
        _ado.SqlQuery = "update Organs set organ_name = @organ_name where organ_id = @organ_id;";
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
                    return Convert.ToBoolean(i);
                }
            });
        }
        catch (Exception)
        {
            return false;
        }
    }
    public async Task<bool> DeleteOrgan(string organ_id)
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
                    _ado.Command.Parameters.AddWithValue("@organ_id", organ_id);
                    _ado.Connection.Open();
                    int i = _ado.Command.ExecuteNonQuery();
                    _ado.Connection.Close();
                    return Convert.ToBoolean(i);
                }
            });
        }
        catch (Exception)
        {
            return false;
        }
    }
    public async Task<Organ> GetOrganById(string organ_id)
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
                    _ado.Command.Parameters.AddWithValue("@organ_id", organ_id);
                    _ado.Connection.Open();
                    _ado.DataReader = _ado.Command.ExecuteReader();
                    while (_ado.DataReader.Read())
                    {
                        organ = new Organ()
                        {
                            OrganId = (string)_ado.DataReader["organ_id"],
                            OrganName = (string)_ado.DataReader["organ_name"]
                        };
                    }
                    _ado.Connection.Close();
                }
                return organ;
            });
        }
        catch (Exception)
        {
            return organ;
        }
    }
    public async Task<List<Organ>> GetOrgans()
    {
        List<Organ> organs = new()!;
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
                            OrganName = (string)_ado.DataReader["organ_name"],
                            OrganId = (string)_ado.DataReader["organ_id"]
                        };
                        organs.Add(organ);
                    }
                    _ado.Connection.Close();
                }
                return organs;
            });
        }
        catch (Exception)
        {
            return organs;
        }
    }
}