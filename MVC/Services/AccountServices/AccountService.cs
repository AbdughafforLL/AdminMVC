using MVC.Models;
using MVC.Models.AccountModels;
using MVC.Services.UserServices;
using MVC.Utils;
namespace MVC.Services.AccountServices;

public class AccountService(IUserService service) : IAccountService
{
	public async Task<Response<GetProfileDto>> GetProfile(int userId)
	{
		var res = await service.GetUserByIdAsync(userId);
		if (res.StatusCode != 200) return new Response<GetProfileDto>(HttpStatusCode.BadRequest,res.Message!);
		var profile = new GetProfileDto();
		return new Response<GetProfileDto>(profile);
	}
	public async Task<Response<List<Claim>>> Login(LoginModel model)
	{
		var res = await service.GetUserByUserNameAsync(model.UserName);
		if (res.StatusCode != 200) return new Response<List<Claim>>(HttpStatusCode.BadRequest, res.Message!);
		if (!BCrypt.Net.BCrypt.Verify(model.Password, res.Data!.HashPassword))
			return new Response<List<Claim>>(HttpStatusCode.BadRequest, "password incorrect");

		var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name, res.Data.UserName),
				new Claim(ClaimTypes.NameIdentifier,res.Data.UserId.ToString())
			};
		return new Response<List<Claim>>(claims);
	}
}