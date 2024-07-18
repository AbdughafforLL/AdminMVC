using System.ComponentModel.DataAnnotations;

namespace MVC.Models.UserModels;

public abstract class BaseUserDto
{
    [MaxLength(100),
     Required(ErrorMessage = "User name require")]
    public required string UserName { get; set; }
    [MaxLength(100),
    DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [MaxLength(100),
     DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }
}