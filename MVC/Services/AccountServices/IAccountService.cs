using MVC.Models;
using MVC.Models.AccountModels;
namespace MVC.Services.AccountServices;
public interface IAccountService
{
	Task<Response<List<Claim>>> Login(LoginModel model);
	Task<Response<GetProfileDto>> GetProfile(int userId);
}