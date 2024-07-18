using System.ComponentModel.DataAnnotations;

namespace MVC.Models.UserModels;

public class UpdateUserDto : BaseUserDto
{
    public required string UserId { get; set; }
    [MaxLength(100)] 
    public string OrganId { get; set; } = null!;
}