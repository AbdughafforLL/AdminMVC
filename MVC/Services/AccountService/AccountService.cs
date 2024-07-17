using System.Net;
using System.Security.Claims;
using MVC.Models;
using MVC.Models.AccountModels;
using MVC.Repositories.UserRepositories;
namespace MVC.Services.AccountService;

public class AccountService(IUserRepository userRepository) : IAccountService
{
    public async Task<Response<List<Claim>>> Login(LoginModel model)
    {
        try
        {
            var user = await userRepository.GetUserByUserName(model.UserName);
            if (user is null)
                return new Response<List<Claim>>(HttpStatusCode.BadRequest, "not found user");

            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.HashPassword))
                return new Response<List<Claim>>(HttpStatusCode.BadRequest, "password incorrect");

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            return new Response<List<Claim>>(claims);
        }
        catch (Exception ex)
        {
            return new Response<List<Claim>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}