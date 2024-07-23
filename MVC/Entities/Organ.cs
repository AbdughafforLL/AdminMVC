namespace MVC.Entities;

public class Organ
{
	public int OrganId { get; set; }
	public required string OrganName { get; set; }
	public string? CreatedAt { get; set; }
	public string? UpdatedAt { get; set; }
}