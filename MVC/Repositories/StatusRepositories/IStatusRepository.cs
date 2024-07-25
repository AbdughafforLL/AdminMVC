using MVC.Entities;

namespace MVC.Repositories.StatusRepositories;
public interface IStatusRepository
{
	Task<(bool, string)> CreateStatusAsync(Status model);
	Task<(bool, string)> UpdateStatusAsync(Status model);
	Task<(bool, string)> DeleteStatusAsync(int statusId);
	Task<(string, Status?)> GetStatusByIdAsync(int statusId);
	Task<(string, List<Status>)> GetStatusesAsync();
}
