using System.Security.Claims;
using MVC.Models;
using MVC.Models.AccountModels;
namespace MVC.Services.AccountService;

public interface IAccountService
{
    Task<Response<List<Claim>>> Login(LoginModel model);
}