using System.ComponentModel.DataAnnotations;

namespace MVC.Models.OrganModels;
public abstract class BaseOrganDto
{
    [MaxLength(100),
        Required(ErrorMessage = "Require Organ name")]
    public required string OrganName { get; set; }
}
