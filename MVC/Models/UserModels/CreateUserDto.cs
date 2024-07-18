using System.ComponentModel.DataAnnotations;

namespace MVC.Models.UserModels;

public class CreateUserDto : BaseUserDto
{
    [MaxLength(100)] 
    public string OrganId { get; set; } = null!;
    public List<int> Roles { get; set; } = new();
    [MaxLength(100),
     DataType(DataType.Password),
     Required(ErrorMessage = "require password")]
    public string Password { get; set; } = null!;

    [MaxLength(100),
     DataType(DataType.Password),
     Compare("Password"),
     Required(ErrorMessage = "require confirm password")]
    public string ComfirmPassword { get; set; } = null!;
}