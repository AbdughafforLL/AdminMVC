using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.AccountModels;
using MVC.Services.AccountServices;
using System.Security.Claims;
namespace MVC.Controllers;

public class AdminController(IAccountService service) : Controller
{
	[Authorize]
	public IActionResult Index()
	{
		var userName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

		var user_id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

		return View();
	}
	public IActionResult Login() => View();
	public async Task<IActionResult> Logout()
	{
		await HttpContext.SignOutAsync();
		return RedirectToAction("Login");
	}

	[HttpPost]
	public async Task<IActionResult> Login(LoginModel model)
	{
		if (!ModelState.IsValid)
			return View(model);

		var res = await service.Login(model);
		if (res.StatusCode != 200)
		{
			ViewBag.Message = res.Message!;
			return View(model);
		}

		var claimsIdentity = new ClaimsIdentity(res.Data, CookieAuthenticationDefaults.AuthenticationScheme);
		var authProperties = new AuthenticationProperties()
		{
			AllowRefresh = true,
			IsPersistent = true,
			ExpiresUtc = DateTime.UtcNow.AddMinutes(10)
		};
		await HttpContext.SignInAsync(
			CookieAuthenticationDefaults.AuthenticationScheme,
			new ClaimsPrincipal(claimsIdentity),
			authProperties
		);
		return RedirectToAction("Index", "Admin");
	}
}