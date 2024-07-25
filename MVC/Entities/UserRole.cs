namespace MVC.Entities;
public class UserRole
{
	public int UserId { get; set; }
	public int RoleId { get; set; }
	public string? CreatedAt { get; set; }
	public string? UpdatedAt { get; set; }
}