namespace MVC.Utils;
public static class SQL
{
	private static async Task<SqlConnection> GetOpenConnectionAsync()
	{
		var conString = new ConfigurationManager().GetConnectionString("DefaultConnection");
		var connection = new SqlConnection(conString);
		await connection.OpenAsync();
		return connection;
	}
	public static async Task<(string, int)> ExecuteNonQueryAsync(string query, params SqlParameter[] parameters)
	{
		try
		{
			using (var connection = await GetOpenConnectionAsync())
			using (var command = new SqlCommand(query, connection))
			{
				command.CommandType = CommandType.StoredProcedure;
				if (parameters != null)
					command.Parameters.AddRange(parameters);
				return ("", await command.ExecuteNonQueryAsync());
			}
		}
		catch (Exception ex)
		{
			return (ex.Message, 0);
		}
	}
	public static async Task<(string,DataTable?)> ExecuteQueryDataTableAsync(string query,params SqlParameter[] parameters)
	{
		try
		{
			using (var connection = await GetOpenConnectionAsync())
			using (var command = new SqlCommand(query, connection))
			using (var adapter = new SqlDataAdapter(command))
			{
				command.CommandType = CommandType.StoredProcedure;
				if (parameters != null)
					command.Parameters.AddRange(parameters);

				var dataTable = new DataTable();
				adapter.Fill(dataTable);
				return ("",dataTable);
			}
		}
		catch (Exception ex)
		{
			return (ex.Message, null);
		}
	}
	public static async Task<(string,DataSet?)> ExecuteQueryDataSetAsync(string query, params SqlParameter[] parameters)
	{
		try
		{
			using (var connection = await GetOpenConnectionAsync())
			using (var command = new SqlCommand(query, connection))
			using (var adapter = new SqlDataAdapter(command))
			{
				if (parameters != null)
					command.Parameters.AddRange(parameters);

				var dataSet = new DataSet();
				adapter.Fill(dataSet);
				return ("", dataSet);
			}
		}
		catch (Exception ex)
		{
			return (ex.Message, null);
		}
	}
}