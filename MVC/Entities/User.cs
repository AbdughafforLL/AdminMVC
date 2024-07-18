namespace MVC.Entities;
public class User
{
    public required string UserId { get; set; }
    public required string UserName { get; set; }
    public string? Email { get; set; }
    public string HashPassword { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? OrganId { get; set; }
}