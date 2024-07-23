namespace MVC.Helpers;

public static class CheckRoleHelper
{
	public static bool CheckSuperAdmin(int userId) => userId == 1 ? true : false;
	public static bool CheckAdmin(int userId) => userId == 1 ? true : false;
}
