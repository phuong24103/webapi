using AssignmentNet105_Client.Services;
using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentNet105_Client.Controllers
{
    public class ColorController : Controller
    {
        TServices _services = new TServices();
        public async Task<IActionResult> Index()
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			return View(await _services.GetAll<Color>("https://localhost:7197/api/color"));
        }
        public async Task<IActionResult> Search(string search)
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			return View("Index", await _services.GetAll<Color>($"https://localhost:7197/api/color/{search}"));
        }
        public async Task<IActionResult> Details(Guid id)
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			return View(await _services.GetAllById<Color>($"https://localhost:7197/api/color/{id}"));
        }
        public IActionResult Create()//Mở form
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Color color)
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			await _services.CreateAll("https://localhost:7197/api/color", color);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)//Mở form
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			var color = await _services.GetAllById<Color>($"https://localhost:7197/api/color/{id}");
            return View(color);
        }
        public async Task<IActionResult> Edit(Color color)
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			await _services.EditAll($"https://localhost:7197/api/color/{color.Id}", color);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            await _services.DeleteAll<Color>($"https://localhost:7197/api/color/{id}");
            return RedirectToAction("Index");
        }
    }
}
