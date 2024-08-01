using MVC.Filters;

namespace MVC.Models.OrganModels;
public class GetOrgansWithFilter
{
    public List<GetOrganDto> Organs { get; set; } = null!;
    public OrganFilter Filter { get; set; } = null!;
}