using MVC.Models.StatusModels;

namespace MVC.Repositories.StatusRepositories;
public interface IProfessionRepository
{
	Task<(bool, string)> CreateProfessionAsync(CreateProfessionDto model);
	Task<(bool, string)> UpdateProfessionAsync(UpdateProfessionDto model);
	Task<(bool, string)> DeleteProfessionAsync(int professionId);
	Task<(string, DataTable?)> GetProfessionByIdAsync(int professionId);
	Task<(string, DataTable?)> GetProfessionsAsync();
}