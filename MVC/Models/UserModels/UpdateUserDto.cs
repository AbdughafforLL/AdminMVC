namespace MVC.Models.UserModels;

public class UpdateUserDto : BaseUserDto
{
	public int UserId { get; set; }
	public string StatusId { get; set; } = null!;
	public int OrganId { get; set; }
	public List<int> Areas { get; set; } = new();
	public List<int> Roles { get; set; } = new();
}