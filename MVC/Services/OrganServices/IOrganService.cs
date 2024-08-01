using MVC.Filters;
using MVC.Models;
using MVC.Models.OrganModels;
namespace MVC.Services.OrganServices;

public interface IOrganService
{
	Task<Response<bool>> CreateOrganAsync(CreateOrganDto model);
	Task<Response<bool>> UpdateOrganAsync(UpdateOrganDto model);
	Task<Response<bool>> DeleteOrganAsync(int organId);
	Task<Response<GetOrganDto>> GetOrganByIdAsync(int organId);
	Task<Response<GetOrgansWithFilter>> GetOrgansWithFilterAsync(OrganFilter model);
	Task<Response<List<GetOrganDto>>> GetOrgansAsync();
}