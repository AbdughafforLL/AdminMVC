using MVC.Repositories.AreaRepositories;
using MVC.Repositories.OrganRepositories;
using MVC.Repositories.RoleRepository;
using MVC.Repositories.ProfessionRepositories;
using MVC.Repositories.UserRepositories;
using MVC.Services.AccountServices;
using MVC.Services.AreaServices;
using MVC.Services.OrganServices;
using MVC.Services.RoleServices;
using MVC.Services.ProfessionServices;
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
		services.AddScoped<IProfessionService, ProfessionService>();
	}
	public static void InjectRepositories(this IServiceCollection services)
	{
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IRoleRepository, RoleRepository>();
		services.AddScoped<IOrganRepository, OrganRepository>();
		services.AddScoped<IAreaRepository, AreaRepository>();
		services.AddScoped<IProfessionRepository, ProfessionRepository>();
	}
}