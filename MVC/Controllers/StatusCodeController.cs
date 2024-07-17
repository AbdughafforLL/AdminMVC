using Microsoft.AspNetCore.Mvc;
namespace MVC.Controllers;

public class StatusCodeController : Controller
{
	public IActionResult NotFoundPage() => View();
    public IActionResult ServerError() => View();
}
