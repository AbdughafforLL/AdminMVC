﻿using MVC.Models.OrganModels;
namespace MVC.Repositories.OrganRepositories;
public interface IOrganRepository
{
	Task<(bool, string)> CreateOrganAsync(CreateOrganDto model);
	Task<(bool, string)> UpdateOrganAsync(UpdateOrganDto model);
	Task<(bool, string)> DeleteOrganAsync(int organId);
	Task<(string,GetOrganDto?)> GetOrganByIdAsync(int organId);
	Task<(string,List<GetOrganDto>)> GetOrgansAsync();
}