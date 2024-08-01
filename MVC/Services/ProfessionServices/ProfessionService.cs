using MVC.Helpers;
using MVC.Models;
using MVC.Models.StatusModels;
using MVC.Repositories.ProfessionRepositories;

namespace MVC.Services.ProfessionServices;
public class ProfessionService(IProfessionRepository statusRepository,IMapper mapper) : IProfessionService
{
	public async Task<Response<bool>> CreateProfessionAsync(CreateProfessionDto model)
	{
		var (res, message) = await statusRepository.CreateProfessionAsync(model);
		if (res) return new Response<bool>(true);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<bool>> UpdateProfessionAsync(UpdateProfessionDto model)
	{
		var (res, message) = await statusRepository.UpdateProfessionAsync(model);
		if (res) return new Response<bool>(true);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<bool>> DeleteProfessionAsync(int professionId)
	{
		var (res, message) = await statusRepository.DeleteProfessionAsync(professionId);
		if (res) return new Response<bool>(true);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<GetProfessionDto>> GetProfessionByIdAsync(int professionId)
	{
		var (message, dt) = await statusRepository.GetProfessionByIdAsync(professionId);
		if (dt is null) return new Response<GetProfessionDto>(HttpStatusCode.BadRequest, message = message == "" ? "not found" : message);
		var profession = mapper.Map<GetProfessionDto>(dt);
		return new Response<GetProfessionDto>(profession);
	}
	public async Task<Response<List<GetProfessionDto>>> GetProfessionsAsync()
	{
		var (message, dt) = await statusRepository.GetProfessionsAsync();
		if (dt is null) return new Response<List<GetProfessionDto>>(HttpStatusCode.BadRequest, message = message == "" ? "добавьте организация" : message);
		var areas = MapHelper.MapDataTableToList<GetProfessionDto>(dt,mapper);
		return new Response<List<GetProfessionDto>>(areas);
	}
}
