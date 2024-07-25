namespace MVC.Models.AreaModels;
public abstract class BaseAreaDto
{
	[MaxLength(100),
		Required(ErrorMessage = "Обязательно заполните имя область")]
	public required string AreaName { get; set; }
}
