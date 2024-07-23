namespace MVC.Models.UserModels;
public class GetUserByIdDto : BaseUserDto
{
	public int UserId { get; set; }
	public string FullName { get; set; } = null!;
	public string StatusName { get; set; } = null!;
	public string CreatedUser { get; set; } = null!;
	public string OrganName { get; set; } = null!;
	public string CreatedAt { get; set; } = null!;
	public string? UpdatedAt { get; set; }
	public List<int> Roles { get; set; } = new();
	public List<int> Areas { get; set; } = new();
}
