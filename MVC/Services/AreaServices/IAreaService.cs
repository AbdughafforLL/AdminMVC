using MVC.Models;
using MVC.Models.AreaModels;

namespace MVC.Services.AreaServices;
public interface IAreaService
{
	Task<Response<bool>> CreateAreaAsync(CreateAreaDto model);
	Task<Response<bool>> UpdateAreaAsync(UpdateAreaDto model);
	Task<Response<bool>> DeleteAreaAsync(int areaId);
	Task<Response<GetAreaDto>> GetAreaByIdAsync(int areaId);
	Task<Response<List<GetAreaDto>>> GetAreasAsync();
}