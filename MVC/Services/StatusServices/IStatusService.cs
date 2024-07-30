using MVC.Models;
using MVC.Models.StatusModels;

namespace MVC.Services.StatusServices;
public interface IStatusService
{
	Task<Response<bool>> CreateStatusAsync(CreateStatusDto model);
	Task<Response<bool>> UpdateStatusAsync(UpdateProfessionDto model);
	Task<Response<bool>> DeleteStatusAsync(int statusId);
	Task<Response<GetStatusDto>> GetStatusByIdAsync(int statusId);
	Task<Response<List<GetStatusDto>>> GetStatusesAsync();
}