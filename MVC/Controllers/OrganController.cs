using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.OrganModels;
using MVC.Services.OrganServices;

namespace MVC.Controllers;

[Authorize]
public class OrganController(IOrganService service) : Controller
{
	public async Task<IActionResult> Index()
	{
		var res = await service.GetOrgansAsync();
		return View(res.Data);
	}

	public IActionResult CreateOrgan() => View();

	public async Task<IActionResult> UpdateOrgan(int organId)
	{
		var res = await service.GetOrganByIdAsync(organId);
		var updateOrgan = new UpdateOrganDto()
		{
			OrganId = res.Data.OrganId,
			OrganName = res.Data.OrganName
		};
		return View(updateOrgan);
	}
	[HttpPost]
	public async Task<IActionResult> UpdateOrgan(UpdateOrganDto model)
	{
		var res = await service.UpdateOrganAsync(model);
		Console.WriteLine(res.Message);
		if (!ModelState.IsValid || res.StatusCode != 200)
			return View(model);
		return RedirectToAction("Index");
	}
	[HttpPost]
	public async Task<IActionResult> CreateOrgan(CreateOrganDto model)
	{
		if (!ModelState.IsValid)
			return View();
		var res = await service.CreateOrganAsync(model);
		if (res.StatusCode != 200)
			return View(model);
		return RedirectToAction("Index");
	}

	public async Task<IActionResult> DeleteOrgan(int organId)
	{
		await service.DeleteOrganAsync(organId);
		return RedirectToAction("Index");
	}
}