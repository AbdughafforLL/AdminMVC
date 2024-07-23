using MVC.Entities;
namespace MVC.Models.OrganModels;
public class GetOrganWithUsers : BaseOrganDto
{
	public required int OrganId { get; set; }
	public List<User> Users { get; set; } = new();
}