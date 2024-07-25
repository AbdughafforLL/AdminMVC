using MVC.Repositories.AreaRepositories;
using MVC.Repositories.OrganRepositories;
using MVC.Repositories.RoleRepository;
using MVC.Repositories.StatusRepositories;
using MVC.Repositories.UserRepositories;
using MVC.Services.AccountServices;
using MVC.Services.AreaServices;
using MVC.Services.OrganServices;
using MVC.Services.RoleServices;
using MVC.Services.StatusServices;
using MVC.Services.UserServices;
namespace MVC.Extentions;
public static class InjectExtentions
{
	public static void InjectServices(this IServiceCollection services)
	{
		services.AddScoped<IAccountService, AccountService>();
		services.AddScoped<IUserService, UserService>();
		services.AddScoped<IOrganService, OrganService>();
		services.AddScoped<IRoleService, RoleService>();
		services.AddScoped<IAreaService, AreaService>();
		services.AddScoped<IStatusService, StatusService>();
	}
	public static void InjectRepositories(this IServiceCollection services)
	{
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IRoleRepository, RoleRepository>();
		services.AddScoped<IOrganRepository, OrganRepository>();
		services.AddScoped<IAreaRepository, AreaRepository>();
		services.AddScoped<IStatusRepository, StatusRepository>();
	}
}