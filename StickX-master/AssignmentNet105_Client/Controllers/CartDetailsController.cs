using AssignmentNet105_Client.Services;
using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Drawing;
using System.Xml.Linq;

namespace AssignmentNet105_Client.Controllers
{
	public class CartDetailsController : Controller
	{
		TServices _services = new TServices();
		public async Task<IActionResult> Index()
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			var result = await _services.GetAll<CartDetailsView>($"https://localhost:7197/api/cartdetails/{user.Id}");
			return View(result);
		}

		/*[Route("[action]/{id}")]
		public async Task<IActionResult> Create(Guid id)
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
				HttpClient httpClient = new HttpClient(); // tạo ra để callApi
				await httpClient.PostAsync($"https://localhost:7197/api/cartdetails/{user.Id}/{id}", null);
				return RedirectToAction("Index", "CartDetails");
			}
			return RedirectToAction("Login", "Login");
		}*/

		[HttpPost]
		public async Task<IActionResult> Create([FromForm] AddProductToCartView product)
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
                HttpClient httpClient = new HttpClient(); // tạo ra để callApi
                var result = await _services.GetAllById<Product>($"https://localhost:7197/api/product/{product.Name}/{product.ColorID}/{product.SizeID}");
				await httpClient.PostAsync($"https://localhost:7197/api/cartdetails/{user.Id}/{result.Id}", null);
				return RedirectToAction("Index", "CartDetails");
			}
			return RedirectToAction("Login", "Login");
		}

		[Route("[action]/{id:Guid}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			await _services.DeleteAll<CartDetails>($"https://localhost:7197/api/cartdetails/{id}");
			return RedirectToAction("Index");
		}

		[Route("[action]/{id:Guid}")]
		public async Task<IActionResult> Increase(Guid id)
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			await _services.EditAll<CartDetails>($"https://localhost:7197/api/cartdetails/Increase/{id}", null);
			return RedirectToAction("Index");
		}

		[Route("[action]/{id:Guid}")]
		public async Task<IActionResult> Reduce(Guid id)
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			await _services.EditAll<CartDetails>($"https://localhost:7197/api/cartdetails/Reduce/{id}", null);
			return RedirectToAction("Index");
		}
	}
}
