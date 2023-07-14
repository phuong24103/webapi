using AssignmentNet105_Client.Services;
using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AssignmentNet105_Client.Controllers
{
	public class RegisterController : Controller
	{
		TServices _services = new TServices();
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(Account account)
		{
			var a = await _services.GetAll<Account>("https://localhost:7197/api/login");
			var result = a.FirstOrDefault(p => p.UserName.Contains(account.UserName));
			if (result != null)
			{
				ModelState.AddModelError("", "Username available!");
			}
			else
			{
				account.RoleId = Guid.Parse("9d76eb12-8c3c-4dcf-a389-4a807ecf0a32");
				account.RankID = Guid.Parse("eaee20af-2adc-4b77-908a-67efb1188734");
				account.Point = 0;
				account.Status = 0;
				await _services.CreateAll("https://localhost:7197/api/register", account);
				Cart cart = new Cart();
				cart.AccountID = account.Id;
                cart.Description = "";
                await _services.CreateAll("https://localhost:7197/api/cart", cart);
                return RedirectToAction("Login", "Login");
			}
			return View();
		}
	}
}
