namespace MVC.Models.StatusModels;
public class GetStatusDto : BaseStatusDto
{
    public int StatusId { get; set; }
    public string CreatedAt { get; set; } = null!;
	public string UpdatedAt { get; set; } = null!;
}
