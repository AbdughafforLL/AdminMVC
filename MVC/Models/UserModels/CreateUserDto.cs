namespace MVC.Models.UserModels;

public class CreateUserDto : BaseUserDto
{
	[Required(ErrorMessage = "Обязательно выберите профессии")]
	public int ProfessionId { get; set; }
	[Required(ErrorMessage = "Обязательно выберите area")]
	public int AreaId { get; set; }
	public int CreatedUserId { get; set; }
	[Required(ErrorMessage = "Обязательно выберите organ")]
	public int OrganId { get; set; }

	[MaxLength(100),
	 DataType(DataType.Password),
	 Required(ErrorMessage = "Обязательно заполните пароль")]
	public string Password { get; set; } = null!;

	[MaxLength(100),
	 DataType(DataType.Password),
	 Required(ErrorMessage = "Обязательно подтвердите пароль"),
	 Compare("Password")]
	public string ComfirmPassword { get; set; } = null!;
}