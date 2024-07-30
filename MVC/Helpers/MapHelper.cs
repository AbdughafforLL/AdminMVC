namespace MVC.Helpers;
public static class MapHelper
{
	public static List<T> MapDataTableToList<T>(DataTable dt,IMapper mapper)
	{
		List<T> result = new List<T>();
		foreach (DataRow row in dt.Rows)
		{
			T item = mapper.Map<T>(row);
			result.Add(item);
		}
		return result;
	}
}
