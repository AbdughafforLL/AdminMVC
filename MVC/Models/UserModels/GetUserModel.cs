namespace MVC.Models.UserModels;

public class GetUserModel : BaseUserModel
{
    public required string UserId { get; set; }
    public string OrganName { get; set; } = null!;
    public List<int> Roles { get; set; } = new();
}