using MVC.Models;
using MVC.Models.UserModels;
namespace MVC.Services.UserServices;

public class UserService : IUserService 
{
    public Task<Response<bool>> CreateUserAsync(CreateUserModel model)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> DeleteUserAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> UpdateUserAsync(UpdateUserModel model)
    {
        throw new NotImplementedException();
    }

    public Task<Response<GetUserModel>> GetUserAsync(GetUserModel model)
    {
        throw new NotImplementedException();
    }

    public Task<Response<List<GetUserModel>>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }
}