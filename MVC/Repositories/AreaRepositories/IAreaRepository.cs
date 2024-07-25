using MVC.Entities;

namespace MVC.Repositories.AreaRepositories;
public interface IAreaRepository
{
	Task<(bool, string)> CreateAreaAsync(Area model);
	Task<(bool, string)> UpdateAreaAsync(Area model);
	Task<(bool, string)> DeleteAreaAsync(int areaId);
	Task<(string, Area?)> GetAreaByIdAsync(int areaId);
	Task<(string, List<Area>)> GetAreasAsync();
}