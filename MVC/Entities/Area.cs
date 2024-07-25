namespace MVC.Entities;
public class Area
{
    public int AreaId { get; set; }
    public required string AreaName { get; set; }
	public string? CreatedAt { get; set; }
	public string? UpdatedAt { get; set; }
}
