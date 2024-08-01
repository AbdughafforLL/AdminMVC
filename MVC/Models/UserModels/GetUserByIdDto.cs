namespace MVC.Models.UserModels;
public class GetUserByIdDto : GetUsersDto
{
	public string HashPassword { get; set; } = null!;
	public List<int> Roles { get; set; } = new();
	public List<int> Areas { get; set; } = new();
}