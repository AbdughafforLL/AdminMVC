using MVC.Repositories.RoleRepository;
using MVC.Repositories.UserRepositories;
using MVC.Services.AccountService;
using MVC.Services.UserServices;

namespace MVC.Extentions;

public static class InjectExtentions
{
    public static void InjectServices(this IServiceCollection services) {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAccountService, AccountService>();
    }
    public static void InjectRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
    }
}
