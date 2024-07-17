namespace MVC.Models.UserModels;

public class UpdateUserModel : BaseUserModel
{
    public required string UserId { get; set; }
    public required string OrganId { get; set; }
    public List<int> Roles { get; set; } = new();
}