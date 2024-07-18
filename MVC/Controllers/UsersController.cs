using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.UserModels;
using MVC.Repositories.OrganRepositories;
using MVC.Services.UserServices;
namespace MVC.Controllers;
[Authorize]
public class UsersController(IUserService service,IOrganRepository organRepository) : Controller
{
	public async Task<IActionResult> Index()
	{
		var res = await service.GetUsersAsync();
		if (res.StatusCode != 200) {
			ViewBag.Message = res.Message;
			return View();
		}
		return View(res.Data);
	}

	public async Task<IActionResult> DeleteUser(string userId)
	{
		var res = await service.DeleteUserAsync(userId);
		if (res.StatusCode != 200)
			ViewBag.Message = res.Message;
		
		return RedirectToAction("Index","Users");
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
		var res = await service.CreateUserAsync(model);
		if (res.StatusCode != 200)
			return View();	
		return RedirectToAction("Index", "Users");
	}

	public async Task<IActionResult> UpdateUser(string userId)
	{
		var res = await service.GetUserByIdAsync(userId);
		var organs = await organRepository.GetOrgans();
		var mappedUser = new UpdateUserDto()
		{
			UserId = res.Data.UserId,
			UserName = res.Data.UserName,
			PhoneNumber = res.Data.PhoneNumber,
			Email = res.Data.Email,
			OrganId = res.Data.OrganId,
		};
		ViewData["Organs"] = organs;
		return View(mappedUser);
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
		return RedirectToAction("Index","Users");
	}
}