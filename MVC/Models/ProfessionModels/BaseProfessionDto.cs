namespace MVC.Models.StatusModels;
public abstract class BaseProfessionDto
{
	[MaxLength(100),
		Required(ErrorMessage = "Обязательно заполните имя организации")]
	public string ProfessionName { get; set; } = null!;
}
