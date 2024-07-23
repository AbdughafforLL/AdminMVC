using System.ComponentModel.DataAnnotations;
namespace MVC.Models.UserModels;

public class CreateUserDto : BaseUserDto
{
	public string StatusId { get; set; } = null!;
	public int? AreaId { get; set; }
	public int CreatedUserId { get; set; }
	public int OrganId { get; set; }

	[MaxLength(100),
	 DataType(DataType.Password)]
	public required string Password { get; set; }

	[MaxLength(100),
	 DataType(DataType.Password),
	 Compare("Password")]
	public required string ComfirmPassword { get; set; }
}