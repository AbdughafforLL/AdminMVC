using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.AccountModels;
using System.Security.Claims;
using MVC.Services.AccountService;
namespace MVC.Controllers;

public class AccountController(IAccountService service) : Controller
{
    public IActionResult Login() => View();
    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var res = await service.Login(model);
        if (res.StatusCode != 200)
        {
            ViewBag.Message = res.Errors;
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

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Login");
    }
}
