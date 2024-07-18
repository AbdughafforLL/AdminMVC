using MVC.Entities;
namespace MVC.Models.OrganModels;
public class GetOrganWithUsers : BaseOrganDto
{
    public required string OrganId { get; set; }
    public List<User> Users { get; set; } = new();
}