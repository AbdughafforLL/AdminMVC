using System.Data.SqlClient;
namespace MVC.Models;

public class SqlAdoModel
{
    public string ConString { get; set; } = string.Empty;
    public string SqlQuery { get; set; } = string.Empty;
    public SqlCommand? Command { get; set; } = null;
    public SqlConnection? Connection { get; set; } = null;
    public SqlDataReader? DataReader { get; set; } = null;
}