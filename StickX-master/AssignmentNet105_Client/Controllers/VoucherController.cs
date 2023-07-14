using AssignmentNet105_Client.Services;
using AssignmentNet105_Shared.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;

namespace AssignmentNet105_Client.Controllers
{
    public class VoucherController : Controller
    {
        TServices _services = new TServices();
        public async Task<IActionResult> Index()
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			return View(await _services.GetAll<Voucher>("https://localhost:7197/api/voucher"));
        }
        public async Task<IActionResult> Search(string search)
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			return View("Index", await _services.GetAll<Voucher>($"https://localhost:7197/api/voucher/{search}"));
        }
        public async Task<IActionResult> Create() // mở form
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Voucher voucher)
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			await _services.CreateAll("https://localhost:7197/api/voucher",voucher);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			var voucher = await _services.GetAllById<Voucher>($"https://localhost:7197/api/voucher/{id}");
            return View(voucher);
        }
        public async Task<IActionResult> Edit(Voucher voucher)
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			await _services.EditAll($"https://localhost:7197/api/voucher/{voucher.Id}",voucher);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(Guid id)
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			await _services.DeleteAll<Voucher>($"https://localhost:7197/api/voucher/{id}");
            return RedirectToAction("Index");

        }
    }
}
