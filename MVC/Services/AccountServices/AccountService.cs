using MVC.Models;
using MVC.Models.AccountModels;
using MVC.Repositories.UserRepositories;
using System.Net;
using System.Security.Claims;
namespace MVC.Services.AccountServices;

public class AccountService(IUserRepository userRepository) : IAccountService
{
	public async Task<Response<List<Claim>>> Login(LoginModel model)
	{
		var (res, message, user) = await userRepository.GetUserByUserName(model.UserName);
		if (!res || user.UserName is null) return new Response<List<Claim>>(HttpStatusCode.BadRequest, message);

		if (!BCrypt.Net.BCrypt.Verify(model.Password, user!.HashPassword))
			return new Response<List<Claim>>(HttpStatusCode.BadRequest, "password incorrect");

		var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString())
			};
		return new Response<List<Claim>>(claims);
	}
}