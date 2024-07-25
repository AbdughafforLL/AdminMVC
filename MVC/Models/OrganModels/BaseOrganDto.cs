namespace MVC.Models.OrganModels;
public abstract class BaseOrganDto
{
	[MaxLength(100),
		Required(ErrorMessage = "Обязательно заполните имя организации")]
	public required string OrganName { get; set; }
}