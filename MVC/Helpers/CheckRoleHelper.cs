namespace MVC.Helpers;

public static class CheckRoleHelper
{
	public static bool CheckSuperAdmin(List<int> roles)
	{
		foreach (int role in roles)
		{
			if (role == 1) return true;
		}
		return false;
	}
	public static bool CheckAdmin(List<int> roles)
	{
		foreach (int role in roles)
		{
			if (role == 2) return true;
		}
		return false;
	}
}