using MVC.Models;
using MVC.Models.UserModels;

namespace MVC.Services.UserServices;

public interface IUserService
{
    Task<Response<bool>> CreateUserAsync(CreateUserModel model);
    Task<Response<bool>> DeleteUserAsync(int userId);
    Task<Response<bool>> UpdateUserAsync(UpdateUserModel model);
    Task<Response<GetUserModel>> GetUserAsync(GetUserModel model);
    Task<Response<List<GetUserModel>>> GetUsersAsync();
}