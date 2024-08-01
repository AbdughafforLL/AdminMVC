namespace MVC.Utils;
internal static class SQL
{
	private static async Task<SqlConnection> GetOpenConnectionAsync()
	{
		var builder = new ConfigurationBuilder().AddJsonFile("appSettings.json", false, false).Build();
		var connection = new SqlConnection(builder.GetConnectionString("DefaultConnection"));
		await connection.OpenAsync();
		return connection;
	}
	internal static async Task<(bool,string)> ExecuteNonQueryAsync(string query, params SqlParameter[] parameters)
	{
		try
		{
			return await Task.Run(async() =>
			{
				using (var connection = await GetOpenConnectionAsync())
				using (var command = new SqlCommand(query, connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					if (parameters != null)
						command.Parameters.AddRange(parameters);
					return (true, "");
				}
			});
		}
		catch (Exception ex)
		{
			return (false,ex.Message);
		}
	}
	internal static async Task<(string,DataTable?)> ExecuteQueryDataTableAsync(string query,params SqlParameter[] parameters)
	{
		try
		{
			return await Task.Run(async () =>
			{
				using (var connection = await GetOpenConnectionAsync())
				using (var command = new SqlCommand(query, connection))
				using (var adapter = new SqlDataAdapter(command))
				{
					command.CommandType = CommandType.StoredProcedure;
					if (parameters != null)
						command.Parameters.AddRange(parameters);

					DataTable dataTable = new();
					adapter.Fill(dataTable);
					return ("", dataTable);
				}
			});
		}
		catch (Exception ex)
		{
			return (ex.Message, null);
		}
	}
	internal static async Task<(string,DataSet?)> ExecuteQueryDataSetAsync(string query, params SqlParameter[] parameters)
	{
		try
		{
			return await Task.Run(async() =>
			{
				using (var connection = await GetOpenConnectionAsync())
				using (var command = new SqlCommand(query, connection))
				using (var adapter = new SqlDataAdapter(command))
				{
					command.CommandType = CommandType.StoredProcedure;
					if (parameters != null)
						command.Parameters.AddRange(parameters);

					DataSet dataSet = new();
					adapter.Fill(dataSet);
					return ("", dataSet);
				}
			});
		}
		catch (Exception ex)
		{
			return (ex.Message, null);
		}
	}
}