using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using MVC.Entities;
using MVC.Models;
using MVC.Models.UserModels;
using MVC.Repositories.OrganRepositories;
using MVC.Repositories.UserRepositories;
using System.Net;
using System.Reflection;
namespace MVC.Services.UserServices;

public class UserService(IUserRepository userRepository,IOrganRepository organRepository,IMapper mapper) : IUserService
{
    public async Task<Response<bool>> CreateUserAsync(CreateUserDto model)
    {
        try
        {
			var user = new User()
			{
				UserId = Guid.NewGuid().ToString(),
				Email = model.Email,
				OrganId = model.OrganId,
				UserName = model.UserName,
				PhoneNumber = model.PhoneNumber,
				HashPassword = BCrypt.Net.BCrypt.HashPassword(model.Password)
			};
			var res = await userRepository.CreateUser(user);
            if (res) return new Response<bool>(res);    
            return new Response<bool>(HttpStatusCode.InternalServerError,"error server");
		}
        catch (Exception ex)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<bool>> DeleteUserAsync(string userId)
    {
		try
		{
			var res = await userRepository.DeleteUser(userId);
			if (res) return new Response<bool>(res);
			return new Response<bool>(HttpStatusCode.InternalServerError, "error server");
		}
		catch (Exception ex)
		{
			return new Response<bool>(HttpStatusCode.InternalServerError, ex.Message);
		}
	}

    public async Task<Response<bool>> UpdateUserAsync(UpdateUserDto model)
    {
	    try
	    {
		    var user = new User()
		    {
			    UserId = model.UserId,
			    UserName = model.UserName,
			    PhoneNumber = model.PhoneNumber,
			    OrganId = model.OrganId,
			    Email = model.Email
		    };
		    var res = await userRepository.UpdateUser(user);
		    if (!res) return new Response<bool>(HttpStatusCode.InternalServerError, "server error");
		    return new Response<bool>(res);
	    }
	    catch (Exception ex)
	    {
		    return new Response<bool>(HttpStatusCode.InternalServerError, ex.Message);
	    }
    }

    public async Task<Response<User>> GetUserByIdAsync(string userId)
    {
	    try
	    {
		    var user = await userRepository.GetUserById(userId);
		    if (user == null) return new Response<User>(HttpStatusCode.BadRequest, "not found user");
		    
		    return new Response<User>(user);
	    }
	    catch (Exception ex)
	    {
		    return new Response<User>(HttpStatusCode.InternalServerError,ex.Message);
	    }
    }

    public async Task<Response<List<GetUsersDto>>> GetUsersAsync()
    {
		try
		{
			var users = await userRepository.GetUsers();
			List<GetUsersDto> usersMapped = mapper.Map<List<GetUsersDto>>(users);
			return new Response<List<GetUsersDto>>(usersMapped);
		}
		catch (Exception ex)
		{
			return new Response<List<GetUsersDto>>(HttpStatusCode.InternalServerError,ex.Message);
		}
    }
}