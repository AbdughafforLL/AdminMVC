using MVC.Helpers;
using MVC.Models;
using MVC.Models.AreaModels;
using MVC.Repositories.AreaRepositories;

namespace MVC.Services.AreaServices;
public class AreaService(IAreaRepository areaRepository,IMapper mapper) : IAreaService
{
	public async Task<Response<bool>> CreateAreaAsync(CreateAreaDto model)
	{
		var (res, message) = await areaRepository.CreateAreaAsync(model);
		if (res) return new Response<bool>(res);
		return new Response<bool>(HttpStatusCode.InternalServerError,message);
    }
	public async Task<Response<bool>> UpdateAreaAsync(UpdateAreaDto model)
	{
		var (res, message) = await areaRepository.UpdateAreaAsync(model);
		if (res) return new Response<bool>(res);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<bool>> DeleteAreaAsync(int areaId)
	{
		var (res, message) = await areaRepository.DeleteAreaAsync(areaId);
		if (res) return new Response<bool>(res);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<GetAreaDto>> GetAreaByIdAsync(int areaId)
	{
		var (message,dt) = await areaRepository.GetAreaByIdAsync(areaId);
		if (dt is null) return new Response<GetAreaDto>(HttpStatusCode.InternalServerError, message);
		var area = mapper.Map<GetAreaDto>(dt);
		return new Response<GetAreaDto>(area);
	}
	public async Task<Response<List<GetAreaDto>>> GetAreasAsync()
	{
		var (message, dt) = await areaRepository.GetAreasAsync();
		if (dt is null) return new Response<List<GetAreaDto>>(HttpStatusCode.InternalServerError, message = message == "" ? "Добавьте область" : message);
		var areas = MapHelper.MapDataTableToList<GetAreaDto>(dt,mapper);
		return new Response<List<GetAreaDto>>(areas);
	}
}