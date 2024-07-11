namespace MVC.Models.UserModels;

public class UpdateUserModel : BaseUserModel
{
    public int UserId { get; set; }
    public int OrganId { get; set; }
    public List<int> Roles { get; set; } = new();
}