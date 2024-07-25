namespace MVC.Entities;
public class Status
{
	public int StatusId { get; set; }
	public required string StatusName { get; set; }
	public string? CreatedAt { get; set; }
	public string? UpdatedAt { get; set; }
}
