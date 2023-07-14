using AssignmentNet105_Client.Models;
using AssignmentNet105_Client.Services;
using AssignmentNet105_Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AssignmentNet105_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		TServices _services;

		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
			_services = new TServices();
		}

        public async Task<IActionResult> Index()
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			var product = await _services.GetAll<ProductView>("https://localhost:7197/api/product");
			var p = product.Where(p => p.Status == 0).GroupBy(p => p.Name).Select(g => g.First()).ToList();
			return View(p);
        }

        public IActionResult Privacy()
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}