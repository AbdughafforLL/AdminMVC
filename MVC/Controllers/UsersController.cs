using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.UserModels;
using MVC.Repositories.OrganRepositories;
using MVC.Services.UserServices;
using System.Security.Claims;
namespace MVC.Controllers;
[Authorize]
public class UsersController(IUserService service, IOrganRepository organRepository) : Controller
{
	public async Task<IActionResult> Index()
	{
		var res = await service.GetUsersAsync();
		if (res.StatusCode != 200)
		{
			ViewBag.Message = res.Message;
			return View();
		}
		return View(res.Data);
	}
	public async Task<IActionResult> DeleteUser(int userId)
	{
		var res = await service.DeleteUserAsync(userId);
		if (res.StatusCode != 200)
			ViewBag.Message = res.Message;
		return RedirectToAction("Index", "Users");
	}
	public async Task<IActionResult> CreateUser()
	{
		var organs = await organRepository.GetOrgans();
		ViewData["Organs"] = organs;
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> CreateUser(CreateUserDto model)
	{
		if (!ModelState.IsValid)
		{
			var organs = await organRepository.GetOrgans();
			ViewData["Organs"] = organs;
			return View(model);
		}
		model.CreatedUserId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

		var res = await service.CreateUserAsync(model);
		if (res.StatusCode != 200)
			return View(model);
		return RedirectToAction("Index", "Users");
	}
	public async Task<IActionResult> UpdateUser(int userId)
	{
		var res = await service.GetUserByIdAsync(userId);
		var organs = await organRepository.GetOrgans();

		ViewData["Organs"] = organs;
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> UpdateUser(UpdateUserDto model)
	{
		if (!ModelState.IsValid)
		{
			var organs = await organRepository.GetOrgans();
			ViewData["Organs"] = organs;
			return View(model);
		}
		var res = await service.UpdateUserAsync(model);
		if (res.StatusCode != 200)
		{
			ViewBag.Message = res.Message;
			return View(model);
		}
		return RedirectToAction("Index", "Users");
	}
}