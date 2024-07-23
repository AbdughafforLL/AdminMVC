namespace MVC.Entities;
public class User
{
	public int UserId { get; set; }
	public string UserName { get; set; }
	public string Ips { get; set; }
	public string Inn { get; set; }
	public string LastName { get; set; }
	public string MiddleName { get; set; }
	public string AdrText { get; set; }
	public string AdrEmail { get; set; }
	public string AdrWebSite { get; set; }
	public string PhoneNumber { get; set; }
	public int OrganId { get; set; }
	public int StatusId { get; set; }
	public int CreatedUserId { get; set; }
	public string HashPassword { get; set; }
	public string? CreatedAt { get; set; }
	public string? UpdatedAt { get; set; }
}