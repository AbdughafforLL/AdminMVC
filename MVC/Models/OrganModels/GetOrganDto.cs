namespace MVC.Models.OrganModels;
public class GetOrganDto : BaseOrganDto
{
	public int OrganId { get; set; }
	public string CreatedAt { get; set; } = null!;
	public string UpdatedAt { get; set; } = null!;
}