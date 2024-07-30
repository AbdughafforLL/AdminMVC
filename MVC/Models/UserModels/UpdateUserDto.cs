namespace MVC.Models.UserModels;

public class UpdateUserDto : BaseUserDto
{
	public int UserId { get; set; }
	public string ProfessionId { get; set; } = null!;
	public int OrganId { get; set; }
	public List<int> Areas { get; set; } = new();
	public List<int> Roles { get; set; } = new();
}