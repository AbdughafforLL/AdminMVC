using MVC.Entities;
namespace MVC.Models.OrganModels;
public class GetOrganDto : BaseOrganDto
{
    public  required string OrganId { get; set; }
}