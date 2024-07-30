using MVC.Helpers;
using MVC.Models;
using MVC.Models.OrganModels;
using MVC.Repositories.OrganRepositories;
namespace MVC.Services.OrganServices;

public class OrganService(IOrganRepository organRepository,IMapper mapper) : IOrganService
{
	public async Task<Response<bool>> CreateOrganAsync(CreateOrganDto model)
	{
		var (res, message) = await organRepository.CreateOrganAsync(model);
		if (res) return new Response<bool>(true);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<bool>> UpdateOrganAsync(UpdateOrganDto model)
	{
		var (res, message) = await organRepository.UpdateOrganAsync(model);
		if (res) return new Response<bool>(true);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<bool>> DeleteOrganAsync(int organId)
	{
		var (res, message) = await organRepository.DeleteOrganAsync(organId);
		if (res) return new Response<bool>(true);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<GetOrganDto>> GetOrganByIdAsync(int organId)
	{
		var (message,dt) = await organRepository.GetOrganByIdAsync(organId);
		if (dt is null) return new Response<GetOrganDto>(HttpStatusCode.BadRequest,message = message==""?"not found":message);
		var organ = mapper.Map<GetOrganDto>(dt);
		return new Response<GetOrganDto>(organ);
	}
	public async Task<Response<List<GetOrganDto>>> GetOrgansAsync()
	{
		var (message,dt) = await organRepository.GetOrgansAsync();
		if (dt is null) return new Response<List<GetOrganDto>>(HttpStatusCode.BadRequest, message = message == "" ? "добавьте организация" : message);
		var organs = MapHelper.MapDataTableToList<GetOrganDto>(dt, mapper);
		return new Response<List<GetOrganDto>>(organs);
	}
}