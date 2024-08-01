namespace MVC.Models.OrganModels;
public abstract class BaseOrganDto
{
	[MaxLength(100),
		Required(ErrorMessage = "Обязательно заполните имя организации")]
	public string? OrganName { get; set; }
}