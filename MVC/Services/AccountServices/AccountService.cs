using MVC.Models;
using MVC.Models.AccountModels;
using MVC.Repositories.UserRepositories;
namespace MVC.Services.AccountServices;

public class AccountService(IUserRepository userRepository,IMapper mapper) : IAccountService
{
	public async Task<Response<GetProfileDto>> GetProfile(int userId)
	{
		var (message,user) = await userRepository.GetUserByIdAsync(userId);
		if (user is null) return new Response<GetProfileDto>(HttpStatusCode.BadRequest,message);
		var mappedUser = mapper.Map<GetProfileDto>(user);
		return new Response<GetProfileDto>(mappedUser);
	}
	public async Task<Response<List<Claim>>> Login(LoginModel model)
	{
		var (message, user) = await userRepository.GetUserByUserNameAsync(model.UserName);
		if (user is null) return new Response<List<Claim>>(HttpStatusCode.BadRequest, message);

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