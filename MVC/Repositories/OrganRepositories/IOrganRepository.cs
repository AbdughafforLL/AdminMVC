using MVC.Entities;
namespace MVC.Repositories.OrganRepositories;
public interface IOrganRepository
{
	Task<(bool, string)> CreateOrganAsync(Organ model);
	Task<(bool, string)> UpdateOrganAsync(Organ model);
	Task<(bool, string)> DeleteOrganAsync(int organId);
	Task<(string,Organ?)> GetOrganByIdAsync(int organId);
	Task<(string,List<Organ>)> GetOrgansAsync();
}