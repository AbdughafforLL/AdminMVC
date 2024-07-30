using MVC.Entities;
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
		var (message,area) = await areaRepository.GetAreaByIdAsync(areaId);
		if (area is null) return new Response<GetAreaDto>(HttpStatusCode.InternalServerError, message);
		var areaMapped = mapper.Map<GetAreaDto>(area);
		return new Response<GetAreaDto>(areaMapped);
	}
	public async Task<Response<List<GetAreaDto>>> GetAreasAsync()
	{
		var (message, areas) = await areaRepository.GetAreasAsync();
		if (areas.Count < 1) return new Response<List<GetAreaDto>>(HttpStatusCode.InternalServerError, message = message == "" ? "Добавьте область" : message);
		var areaMapped = mapper.Map<List<GetAreaDto>>(areas);
		return new Response<List<GetAreaDto>>(areaMapped);
	}
}