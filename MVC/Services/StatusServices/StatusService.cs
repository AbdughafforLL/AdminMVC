using MVC.Entities;
using MVC.Models;
using MVC.Models.StatusModels;
using MVC.Repositories.StatusRepositories;

namespace MVC.Services.StatusServices;
public class StatusService(IStatusRepository statusRepository,IMapper mapper) : IStatusService
{
	public async Task<Response<bool>> CreateStatusAsync(CreateStatusDto model)
	{
		var status = mapper.Map<Status>(model);
		var (res, message) = await statusRepository.CreateStatusAsync(status);
		if (res) return new Response<bool>(true);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<bool>> UpdateStatusAsync(UpdateStatusDto model)
	{
		var status = mapper.Map<Status>(model);
		var (res, message) = await statusRepository.UpdateStatusAsync(status);
		if (res) return new Response<bool>(true);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<bool>> DeleteStatusAsync(int statusId)
	{
		var (res, message) = await statusRepository.DeleteStatusAsync(statusId);
		if (res) return new Response<bool>(true);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<GetStatusDto>> GetStatusByIdAsync(int statusId)
	{
		var (message, status) = await statusRepository.GetStatusByIdAsync(statusId);
		if (status is null) return new Response<GetStatusDto>(HttpStatusCode.BadRequest, message = message == "" ? "not found" : message);
		var mapped = mapper.Map<GetStatusDto>(status);
		return new Response<GetStatusDto>(mapped);
	}
	public async Task<Response<List<GetStatusDto>>> GetStatusesAsync()
	{
		var (message, statuses) = await statusRepository.GetStatusesAsync();
		if (statuses.Count < 1) return new Response<List<GetStatusDto>>(HttpStatusCode.BadRequest, message = message == "" ? "добавьте организация" : message);
		var mapped = mapper.Map<List<GetStatusDto>>(statuses);
		return new Response<List<GetStatusDto>>(mapped);
	}
}
