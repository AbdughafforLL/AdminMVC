using MVC.Models;
using MVC.Models.AccountModels;
using System.Security.Claims;
namespace MVC.Services.AccountServices;

public interface IAccountService
{
	Task<Response<List<Claim>>> Login(LoginModel model);
}