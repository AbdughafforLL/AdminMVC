namespace MVC.Models.StatusModels;
public abstract class BaseStatusDto
{
	[MaxLength(100),
		Required(ErrorMessage = "")]
	public string StatusName { get; set; } = null!;
}
