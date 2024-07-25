namespace MVC.Entities;
public class User
{
	public int UserId { get; set; }
	public string UserName { get; set; } = null!;
	public string Ips { get; set; } = null!;
	public string Inn { get; set; } = null!;
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string MiddleName { get; set; } = null!;
	public string? FullName { get; set; }
	public string AdrText { get; set; } = null!;
	public string AdrEmail { get; set; } = null!;
	public string AdrWebSite { get; set; } = null!;
	public string PhoneNumber { get; set; } = null!;
	public int OrganId { get; set; }
	public int StatusId { get; set; }
	public int CreatedUserId { get; set; }
	public string HashPassword { get; set; } = null!;
	public string? CreatedAt { get; set; }
	public string? UpdatedAt { get; set; }
}