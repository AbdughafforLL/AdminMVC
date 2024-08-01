namespace MVC.Helpers;
public static class MapHelper
{
	public static List<T> MapDataTableToList<T>(DataTable dt,IMapper mapper)
	{
		List<T> result = new ();
		foreach (DataRow row in dt.Rows)
		{
			T item = mapper.Map<T>(row);
			result.Add(item);
		}
		return result;
	}
	public static List<int> DataTableToList(DataTable dataTable, string columnName)
	{
		List<int> list = new ();

		foreach (DataRow row in dataTable.Rows)
			if (row[columnName] != DBNull.Value)
				list.Add(Convert.ToInt32(row[columnName]));
		return list;
	}
	public static int DataTableToInt(DataTable dataTable, string columnName)
	{
		int number = 0;
		foreach (DataRow row in dataTable.Rows)
			if (row[columnName] != DBNull.Value)
				number = Convert.ToInt32(row[columnName]);
		return number;
	}
	public static string DataTableToString(DataTable dataTable, string columnName)
	{
		string message = "";
		foreach (DataRow row in dataTable.Rows)
			if (row[columnName] != DBNull.Value)
				message = Convert.ToString(row[columnName])!;
		return message;
	}
}
