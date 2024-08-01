using MVC.Filters;
using MVC.Models.OrganModels;
using MVC.Services.OrganServices;
namespace MVC.Controllers;

[Authorize]
public class OrganController(IOrganService service,IMapper mapper) : Controller
{
	public async Task<IActionResult> Index(OrganFilter model)
	{
		var res = await service.GetOrgansWithFilterAsync(model);
		if (res.StatusCode != 200) {
			ViewBag.Message = res.Message;
		}
		ViewData["Organs"] = res.Data!.Organs;
		return View(res.Data.Filter);
	}
	public IActionResult CreateOrgan() => View();
	[HttpPost]
	public async Task<IActionResult> CreateOrgan(CreateOrganDto model)
	{
		if (!ModelState.IsValid)
			return View(model);
		var res = await service.CreateOrganAsync(model);
		if (res.StatusCode != 200)
		{
			ViewBag.Message = res.Message;
			return View(model);
		}
		return RedirectToAction("Index");
	}
	public async Task<IActionResult> UpdateOrgan(int organId)
	{
		var res = await service.GetOrganByIdAsync(organId);
		if(res.StatusCode != 200)
		{
			ViewBag.Message = res.Message;
			return RedirectToAction("Index");
		}
		var updateOrgan = mapper.Map<UpdateOrganDto>(res.Data);
		return View(updateOrgan);
	}
	[HttpPost]
	public async Task<IActionResult> UpdateOrgan(UpdateOrganDto model)
	{
		if (!ModelState.IsValid)
			return View(model);
		
		var res = await service.UpdateOrganAsync(model);
		if (res.StatusCode != 200) {
			ViewBag.Message = res.Message;
			return View(model);
		}
		return RedirectToAction("Index");
	}
	public async Task<IActionResult> DeleteOrgan(int organId)
	{
		await service.DeleteOrganAsync(organId);
		return RedirectToAction("Index");
	}
}