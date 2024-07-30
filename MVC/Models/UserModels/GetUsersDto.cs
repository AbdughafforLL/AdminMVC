namespace MVC.Models.UserModels;
public class GetUsersDto : BaseUserDto
{
	public int UserId { get; set; }
	public string FullName { get; set; } = null!;
	public string ProfessionName { get; set; } = null!;
	public string CreatedUser { get; set; } = null!;
	public string OrganName { get; set; } = null!;
	public string CreatedAt { get; set; } = null!;
	public string? UpdatedAt { get; set; }
}
