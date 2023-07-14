using AssignmentNet105_Client.Services;
using AssignmentNet105_Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentNet105_Client.Controllers
{
	public class RankController : Controller
	{
		TServices _services = new TServices();

		public async Task<IActionResult> Index()
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			return View(await _services.GetAll<Rank>("https://localhost:7197/api/rank"));
		}
		public async Task<IActionResult> Search(string search)
		{
			return View(await _services.GetAll<Rank>($"https://localhost:7197/api/rank/{search}"));
		}

		public IActionResult Create()
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Rank rank)
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			await _services.CreateAll("https://localhost:7197/api/size", rank);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)// mở form
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            var size = await _services.GetAllById<Size>($"https://localhost:7197/api/rank/{id}");
			return View(size);
		}
		public async Task<IActionResult> Edit(Rank rank)
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            await _services.EditAll($"https://localhost:7197/api/rank/{rank.Id}", rank);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Delete(Guid id)
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            await _services.DeleteAll<Rank>($"https://localhost:7197/api/size/{id}");
			return RedirectToAction("Index");
		}
	}
}
