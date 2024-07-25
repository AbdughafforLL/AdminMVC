namespace MVC.Models.AreaModels;
public class GetAreaDto : BaseAreaDto
{
    public int AreaId { get; set; }
    public string CreatedAt { get; set; } = null!;
	public string UpdatedAt { get; set; } = null!;
}