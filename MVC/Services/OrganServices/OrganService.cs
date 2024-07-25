using MVC.Entities;
using MVC.Models;
using MVC.Models.OrganModels;
using MVC.Repositories.OrganRepositories;
namespace MVC.Services.OrganServices;

public class OrganService(IOrganRepository organRepository,IMapper mapper) : IOrganService
{
	public async Task<Response<bool>> CreateOrganAsync(CreateOrganDto model)
	{
		var organ = mapper.Map<Organ>(model);
		var (res, message) = await organRepository.CreateOrganAsync(organ);
		if (res) return new Response<bool>(true);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<bool>> UpdateOrganAsync(UpdateOrganDto model)
	{
		var organ = mapper.Map<Organ>(model);
		var (res, message) = await organRepository.UpdateOrganAsync(organ);
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
		var (message,organ) = await organRepository.GetOrganByIdAsync(organId);
		if (organ is null) return new Response<GetOrganDto>(HttpStatusCode.BadRequest,message = message==""?"not found":message);
		var mapped = mapper.Map<GetOrganDto>(organ);
		return new Response<GetOrganDto>(mapped);
	}
	public async Task<Response<List<GetOrganDto>>> GetOrgansAsync()
	{
		var (message,organs) = await organRepository.GetOrgansAsync();
		if (organs.Count < 1) return new Response<List<GetOrganDto>>(HttpStatusCode.BadRequest, message = message == "" ? "добавьте организация" : message);
		var mapped = mapper.Map<List<GetOrganDto>>(organs);
		return new Response<List<GetOrganDto>>(mapped);
	}
}