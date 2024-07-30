using MVC.Models.AreaModels;

namespace MVC.Repositories.AreaRepositories;
public interface IAreaRepository
{
	Task<(bool, string)> CreateAreaAsync(CreateAreaDto model);
	Task<(bool, string)> UpdateAreaAsync(UpdateAreaDto model);
	Task<(bool, string)> DeleteAreaAsync(int areaId);
	Task<(string, GetAreaDto?)> GetAreaByIdAsync(int areaId);
	Task<(string, List<GetAreaDto>)> GetAreasAsync();
}