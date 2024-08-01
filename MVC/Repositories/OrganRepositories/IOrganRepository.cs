using MVC.Filters;
using MVC.Models.OrganModels;
namespace MVC.Repositories.OrganRepositories;
public interface IOrganRepository
{
	Task<(string,DataTable)> CreateOrganAsync(CreateOrganDto model);
	Task<(string,DataTable)> UpdateOrganAsync(UpdateOrganDto model);
	Task<(string,DataTable)> DeleteOrganAsync(int organId);
	Task<(string,DataTable?)> GetOrganByIdAsync(int organId);
	Task<(string,DataSet?)> GetOrgansWithFilterAsync(OrganFilter model);
	Task<(string,DataTable?)> GetOrgansAsync();
}