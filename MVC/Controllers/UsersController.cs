using MVC.Filters;
using MVC.Helpers;
using MVC.Models.UserModels;
using MVC.Services.AreaServices;
using MVC.Services.OrganServices;
using MVC.Services.StatusServices;
using MVC.Services.UserServices;
namespace MVC.Controllers;
[Authorize]
public class UsersController(IUserService service,IOrganService organService,
			IStatusService statusService,IAreaService areaService) : Controller
{
	public async Task<IActionResult> Index(UserFilters model)
	{
		var res = await service.GetUsersAsync(model);
		if (res.StatusCode != 200)
		{
			ViewBag.Message = res.Message;
			return View();
		}
		return View(res.Data);
	}
	public async Task<IActionResult> DeleteUser(int userId)
	{
		var user_id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
		var resRoles = await service.GetRolesByUserIdAsync(user_id);
		if (resRoles.StatusCode != 200) { 
			ViewBag.Message = resRoles.Message;
			return RedirectToAction("Index");
		}
		if (!CheckRoleHelper.CheckSuperAdmin(resRoles.Data!))
		{
			ViewBag.Message = "У вас нет доступ";
			return RedirectToAction("Index", "Users");
		}
		var resUser = await service.DeleteUserAsync(userId);
		if (resUser.StatusCode != 200)
			ViewBag.Message = resUser.Message;
		return RedirectToAction("Index", "Users");
	}

	public async Task<IActionResult> CreateUser()
	{
		var resStatus = await statusService.GetStatusesAsync();
		var resAreas = await areaService.GetAreasAsync();
		var resOrgans = await organService.GetOrgansAsync();
		ViewData["Organs"] = resOrgans.StatusCode != 200 ? resOrgans.Message : resOrgans.Data;
		ViewData["Areas"] = resAreas.StatusCode != 200 ? resAreas.Message : resAreas.Data;
		ViewData["Statuses"] = resStatus.StatusCode != 200 ? resStatus.Message : resStatus.Data;
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> CreateUser(CreateUserDto model)
	{
		var resStatus = await statusService.GetStatusesAsync();
		var resAreas = await areaService.GetAreasAsync();
		var resOrgans = await organService.GetOrgansAsync();
		if (!ModelState.IsValid)
		{
			ViewData["Organs"] = resOrgans.StatusCode != 200 ? resOrgans.Message : resOrgans.Data;
			ViewData["Areas"] = resAreas.StatusCode != 200 ? resAreas.Message : resAreas.Data;
			ViewData["Statuses"] = resStatus.StatusCode != 200 ? resStatus.Message : resStatus.Data;
			return View(model);
		}
		model.CreatedUserId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

		var res = await service.CreateUserAsync(model);
		if (res.StatusCode != 200) {
			ViewBag.Message = res.Message;
			ViewData["Organs"] = resOrgans.StatusCode != 200 ? resOrgans.Message : resOrgans.Data;
			ViewData["Areas"] = resAreas.StatusCode != 200 ? resAreas.Message : resAreas.Data;
			ViewData["Statuses"] = resStatus.StatusCode != 200 ? resStatus.Message : resStatus.Data;
			return View(model);
		}	
		return RedirectToAction("Index", "Users");
	}
	public async Task<IActionResult> UpdateUser(int userId)
	{
		var res = await service.GetUserByIdAsync(userId);
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> UpdateUser(UpdateUserDto model)
	{
		if (!ModelState.IsValid)
			return View(model);
		
		var res = await service.UpdateUserAsync(model);
		if (res.StatusCode != 200)
		{
			ViewBag.Message = res.Message;
			return View(model);
		}
		return RedirectToAction("Index", "Users");
	}
}