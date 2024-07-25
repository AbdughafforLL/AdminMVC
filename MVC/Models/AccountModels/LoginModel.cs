namespace MVC.Models.AccountModels;

public class LoginModel
{
	[MaxLength(100),
	 Required(ErrorMessage = "Обязательно заполните имя пользователя")]
	public string UserName { get; set; } = null!;
	[MaxLength(100),
	 Required(ErrorMessage = "Обязательно заполните пароль"),
	DataType(DataType.Password)]
	public string Password { get; set; } = null!;
}