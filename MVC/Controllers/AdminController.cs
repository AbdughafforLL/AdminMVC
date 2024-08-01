using MVC.Models.AccountModels;
using MVC.Services.AccountServices;
namespace MVC.Controllers;
[Authorize]
public class AdminController(IAccountService service) : Controller
{ 
	public IActionResult Index()
	{
		return View();
	}
	public async Task<IActionResult> Profile()
	{
		var user_id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
		var res = await service.GetProfile(user_id);
		if (res.StatusCode != 200) 
			return RedirectToAction("Index");
		return View(res.Data);
	}


	[AllowAnonymous]
	public IActionResult Login() => View();

	[HttpPost,AllowAnonymous]
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
			ExpiresUtc = DateTime.UtcNow.AddHours(1)
		};
		await HttpContext.SignInAsync(
			CookieAuthenticationDefaults.AuthenticationScheme,
			new ClaimsPrincipal(claimsIdentity),
			authProperties
		);
		return RedirectToAction("Index", "Admin");
	}
	public async Task<IActionResult> Logout()
	{
		await HttpContext.SignOutAsync();
		return RedirectToAction("Login");
	}
}