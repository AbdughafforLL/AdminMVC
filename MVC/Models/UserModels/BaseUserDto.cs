namespace MVC.Models.UserModels;

public abstract class BaseUserDto
{
	public string UserName { get; set; } = null!;
	public string Ips { get; set; } = null!;
	public string Inn { get; set; } = null!;
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string MiddleName { get; set; } = null!;
	public string PhoneNumber { get; set; } = null!;
	public string AdrText { get; set; } = null!;
	public string AdrEmail { get; set; } = null!;
	public string AdrWebSite { get; set; } = null!;
}