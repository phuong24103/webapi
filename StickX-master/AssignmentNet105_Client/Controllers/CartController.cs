using AssignmentNet105_Client.Services;
using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentNet105_Client.Controllers
{
	public class CartController : Controller
	{
		TServices _services = new TServices();

		public async Task<IActionResult> Index()
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            return View(await _services.GetAll<BillView>("https://localhost:7197/api/cart"));
		}
		public async Task<IActionResult> Search(string search)
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            return View(await _services.GetAll<BillView>($"https://localhost:7197/api/cart/{search}"));
		}
		public async Task<IActionResult> Details(Guid id)
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            return View(await _services.GetAllById<BillView>($"https://localhost:7197/api/cart/{id}"));
		}

		public async Task<IActionResult> Create(Cart cart)
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            await _services.CreateAll("https://localhost:7197/api/cart", cart);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Delete(Guid id)
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            await _services.DeleteAll<Cart>($"https://localhost:7197/api/cart/{id}");
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Edit(Guid id)
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            var bill = await _services.GetAllById<Cart>($"https://localhost:7197/api/cart/{id}");
			return View(bill);
		}
		public async Task<IActionResult> Edit(Cart cart)
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            await _services.EditAll($"https://localhost:7197/api/{cart.AccountID}", cart);
			return RedirectToAction("Index");
		}

	}
}
