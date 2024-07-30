namespace MVC.Models.RoleModels;
public class GetRoleDto : BaseRoleDto
{
    public int RoleId { get; set; }
	public string CreatedAt { get; set; } = null!;
	public string UpdatedAt { get; set; } = null!;
}
