namespace MVC.Models.UserModels;

public class CreateUserModel : BaseUserModel
{
    public int OrganId { get; set; }
    public List<int> Roles { get; set; } = new();
    public required string HashPassword { get; set; }
}