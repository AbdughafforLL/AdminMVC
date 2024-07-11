using System.ComponentModel.DataAnnotations;

namespace MVC.Models.AccountModels;

public class LoginModel
{
    [MaxLength(100),
     Required(ErrorMessage = "Username required")]
    public string UserName { get; set; } = null!;
    [MaxLength(100),
     Required(ErrorMessage = "Password required"),
    DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}