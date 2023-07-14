using AssignmentNet105_Client.Services;
using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentNet105_Client.Controllers
{
	public class BillDetailsController : Controller
	{
		TServices _services = new TServices();
		public async Task<IActionResult> Index(Guid id)
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			return View(await _services.GetAll<BillDetailsView>($"https://localhost:7197/api/billdetails/{id}"));
		}
		public async Task<IActionResult> Search(string search)
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			return View(await _services.GetAll<BillDetailsView>($"https://localhost:7197/api/billdetails/{search}"));
		}
		public async Task<IActionResult> Delete(Guid id)
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			await _services.DeleteAll<BillDetails>($"https://localhost:7197/api/billdetails/{id}");
			return RedirectToAction("Index");
		}

	}
}
