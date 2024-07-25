namespace MVC.Models.UserModels;

public abstract class BaseUserDto
{
	[MaxLength(100),
	Required(ErrorMessage = "Обязательно заполните имя пользователя")]
	public string UserName { get; set; } = null!;
	[MaxLength(500),
	Required(ErrorMessage = "Обязательно заполните ips")]
	public string Ips { get; set; } = null!;
	[MaxLength(100),
	Required(ErrorMessage = "Обязательно заполните ИНН")]
	public string Inn { get; set; } = null!;
	[MaxLength(100),
	Required(ErrorMessage = "Обязательно заполните имя")]
	public string FirstName { get; set; } = null!;
	[MaxLength(100),
	Required(ErrorMessage = "Обязательно заполните фамилия")]
	public string LastName { get; set; } = null!;
	[MaxLength(100),
	Required(ErrorMessage = "Обязательно заполните отчество")]
	public string MiddleName { get; set; } = null!;
	[MaxLength(100),
	Required(ErrorMessage = "Обязательно заполните номер телефона")]
	public string PhoneNumber { get; set; } = null!;
	[MaxLength(100),
	Required(ErrorMessage = "Обязательно заполните адрес")]
	public string AdrText { get; set; } = null!;
	[MaxLength(100),
	Required(ErrorMessage = "Обязательно заполните email")]
	public string AdrEmail { get; set; } = null!;
	[MaxLength(100),
	Required(ErrorMessage = "Обязательно заполните website")]
	public string AdrWebSite { get; set; } = null!;
}