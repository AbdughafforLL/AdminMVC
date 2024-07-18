using MVC.Entities;
namespace MVC.Repositories.OrganRepositories;
public interface IOrganRepository
{
    Task<bool> CreateOrgan(Organ model);
    Task<bool> UpdateOrgan(Organ model);
    Task<bool> DeleteOrgan(string organ_id);
    Task<Organ> GetOrganById(string organ_id);
    Task<List<Organ>> GetOrgans();
}