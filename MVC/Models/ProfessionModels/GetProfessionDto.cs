namespace MVC.Models.StatusModels;
public class GetProfessionDto : BaseProfessionDto
{
    public int ProfessionId { get; set; }
    public string CreatedAt { get; set; } = null!;
	public string UpdatedAt { get; set; } = null!;
}
