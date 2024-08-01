using MVC.Models;
using MVC.Models.StatusModels;

namespace MVC.Services.ProfessionServices;
public interface IProfessionService
{
	Task<Response<bool>> CreateProfessionAsync(CreateProfessionDto model);
	Task<Response<bool>> UpdateProfessionAsync(UpdateProfessionDto model);
	Task<Response<bool>> DeleteProfessionAsync(int professionId);
	Task<Response<GetProfessionDto>> GetProfessionByIdAsync(int professionId);
	Task<Response<List<GetProfessionDto>>> GetProfessionsAsync();
}