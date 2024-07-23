using AutoMapper;
using MVC.Entities;
using MVC.Models;
using MVC.Models.OrganModels;
using MVC.Repositories.OrganRepositories;
using MVC.Repositories.UserRepositories;
using System.Net;

namespace MVC.Services.OrganServices;

public class OrganService(IOrganRepository organRepository, IUserRepository userRepository, IMapper mapper) : IOrganService
{
	public async Task<Response<bool>> CreateOrganAsync(CreateOrganDto model)
	{
		var organ = new Organ()
		{
			OrganName = model.OrganName
		};
		var (res, message) = await organRepository.CreateOrgan(organ);
		if (res) return new Response<bool>(true);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<bool>> UpdateOrganAsync(UpdateOrganDto model)
	{
		var organ = new Organ()
		{
			OrganId = model.OrganId,
			OrganName = model.OrganName
		};
		var (res, message) = await organRepository.UpdateOrgan(organ);
		if (res) return new Response<bool>(true);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<bool>> DeleteOrganAsync(int organId)
	{
		var (res, message) = await organRepository.DeleteOrgan(organId);
		if (res) return new Response<bool>(true);
		return new Response<bool>(HttpStatusCode.InternalServerError, message);
	}
	public async Task<Response<GetOrganDto>> GetOrganByIdAsync(int organId)
	{
		var res = await organRepository.GetOrganById(organId);
		if (res.OrganName == "") return new Response<GetOrganDto>(HttpStatusCode.BadRequest, "not found organ");
		var mapped = new GetOrganDto()
		{
			OrganId = res.OrganId,
			OrganName = res.OrganName
		};
		return new Response<GetOrganDto>(mapped);
	}
	public async Task<Response<List<GetOrganDto>>> GetOrgansAsync()
	{
		var organs = await organRepository.GetOrgans();
		var mapped = mapper.Map<List<GetOrganDto>>(organs);
		return new Response<List<GetOrganDto>>(mapped);
	}
}