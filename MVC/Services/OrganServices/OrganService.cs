using MVC.Filters;
using MVC.Helpers;
using MVC.Models;
using MVC.Models.OrganModels;
using MVC.Repositories.OrganRepositories;

namespace MVC.Services.OrganServices;

public class OrganService(IOrganRepository organRepository,IMapper mapper) : IOrganService
{
	public async Task<Response<bool>> CreateOrganAsync(CreateOrganDto model)
	{
		var (message,dt) = await organRepository.CreateOrganAsync(model);
		if (!string.IsNullOrEmpty(message))
			return new Response<bool>(HttpStatusCode.InternalServerError, message);
		var statusCode = MapHelper.DataTableToInt(dt,"status_code");
		switch (statusCode)
		{
			case 1:
				return new Response<bool>(true);
			case 3:
				return new Response<bool>(HttpStatusCode.BadRequest,"По таким именам уже существует организация.");
			default:
				var status_message = MapHelper.DataTableToString(dt, "status_message");
				return new Response<bool>(HttpStatusCode.BadRequest, status_message);
		}
	}
	public async Task<Response<bool>> UpdateOrganAsync(UpdateOrganDto model)
	{
		var (message, dt) = await organRepository.UpdateOrganAsync(model);
		if (!string.IsNullOrEmpty(message))
			return new Response<bool>(HttpStatusCode.InternalServerError, message);
		var statusCode = MapHelper.DataTableToInt(dt, "status_code");
		switch (statusCode)
		{
			case 1:
				return new Response<bool>(true);
			case 3:
				return new Response<bool>(HttpStatusCode.BadRequest, "По таким именам уже существует организация.");
			default:
				var status_message = MapHelper.DataTableToString(dt, "status_message");
				return new Response<bool>(HttpStatusCode.BadRequest, status_message);
		}
	}
	public async Task<Response<bool>> DeleteOrganAsync(int organId)
	{
		var (message, dt) = await organRepository.DeleteOrganAsync(organId);
		if (!string.IsNullOrEmpty(message))
			return new Response<bool>(HttpStatusCode.InternalServerError, message);
		var statusCode = MapHelper.DataTableToInt(dt, "status_code");
		string status_message = MapHelper.DataTableToString(dt, "status_message");
		switch (statusCode)
		{
			case 1:
				return new Response<bool>(true);
			case 3:
				return new Response<bool>(HttpStatusCode.BadRequest, status_message);
			default:
				return new Response<bool>(HttpStatusCode.BadRequest, status_message);
		}
	}
	public async Task<Response<GetOrganDto>> GetOrganByIdAsync(int organId)
	{
		var (message,dt) = await organRepository.GetOrganByIdAsync(organId);
		if (dt is null) return new Response<GetOrganDto>(HttpStatusCode.BadRequest,string.IsNullOrEmpty(message)?"not found":message);
		GetOrganDto organ = new ();
		foreach (var dr in dt.Rows)
			organ = mapper.Map<GetOrganDto>(dr);
		return new Response<GetOrganDto>(organ);
	}
	public async Task<Response<GetOrgansWithFilter>> GetOrgansWithFilterAsync(OrganFilter model)
	{
		var (message,ds) = await organRepository.GetOrgansWithFilterAsync(model);
		if (ds is null) return new Response<GetOrgansWithFilter>(HttpStatusCode.BadRequest, message = message == "" ? "добавьте организация" : message);
		model.TotalRecords = MapHelper.DataTableToInt(ds.Tables[1], "count");
		model.PageCount = (int)Math.Ceiling(model.TotalRecords / (double)model.PageSize);
		var organs = new GetOrgansWithFilter()
		{
			Organs = MapHelper.MapDataTableToList<GetOrganDto>(ds.Tables[0], mapper),
			Filter = model
		};
		return new Response<GetOrgansWithFilter>(organs);
	}
	public async Task<Response<List<GetOrganDto>>> GetOrgansAsync()
	{
		var (message, dt) = await organRepository.GetOrgansAsync();
		if (dt is null) return new Response<List<GetOrganDto>>(HttpStatusCode.BadRequest, message = message == "" ? "добавьте организация" : message);
		var organs = MapHelper.MapDataTableToList<GetOrganDto>(dt, mapper);
		return new Response<List<GetOrganDto>>(organs);
	}
}