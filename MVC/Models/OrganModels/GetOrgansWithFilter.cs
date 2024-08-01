using MVC.Filters;

namespace MVC.Models.OrganModels;
public class GetOrgansWithFilter
{
    public List<GetOrganDto> Organs { get; set; }
    public OrganFilter Filter{ get; set; }
}
