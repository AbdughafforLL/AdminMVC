using MVC.Entities;
namespace MVC.Repositories.OrganRepositories;
public interface IOrganRepository
{
	Task<(bool, string)> CreateOrgan(Organ model);
	Task<(bool, string)> UpdateOrgan(Organ model);
	Task<(bool, string)> DeleteOrgan(int organId);
	Task<Organ> GetOrganById(int organId);
	Task<List<Organ>> GetOrgans();
}