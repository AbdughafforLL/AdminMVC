using MVC.Entities;
using MVC.Models;
using MVC.Models.UserModels;

namespace MVC.Services.UserServices;

public interface IUserService
{
    Task<Response<bool>> CreateUserAsync(CreateUserDto model);
    Task<Response<bool>> DeleteUserAsync(string userId);
    Task<Response<bool>> UpdateUserAsync(UpdateUserDto model);
    Task<Response<User>> GetUserByIdAsync(string userId);
    Task<Response<List<GetUsersDto>>> GetUsersAsync();
}