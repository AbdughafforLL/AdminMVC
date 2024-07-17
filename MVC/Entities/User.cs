namespace MVC.Entities;
public class User
{
    public required string UserId { get; set; }
    public required string UserName { get; set; }
    public string? Email { get; set; }
    public required string HashPassword { get; set; }
    public string? PhoneNumber { get; set; }
    public string? OrganId { get; set; }
}