namespace MVC.Entities;

public class Role
{
	public int RoleId { get; set; }
	public required string RoleName { get; set; }
	public string? CreatedAt { get; set; }
	public string? UpdatedAt { get; set; }
}