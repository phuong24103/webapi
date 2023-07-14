using AssignmentNet105_Client.Services;
using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentNet105_Client.Controllers
{
	public class FavoriteProductsController : Controller
	{
		TServices _services = new TServices();
		public async Task<IActionResult> Index()
		{
			var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
			if (user.Status != 404)
			{
				ViewBag.RoleId = user.RoleId;
			}
			var favoriteProduct = await _services.GetAll<FavoriteProductsView>($"https://localhost:7197/api/favoriteProducts/{user.Id}");
			foreach (var item in favoriteProduct)
			{
				var color = await _services.GetAllById<Color>($"https://localhost:7197/api/color/{item.Product.ColorID}");
				var size = await _services.GetAllById<Size>($"https://localhost:7197/api/size/{item.Product.SizeID}");
				item.Product.Color = color;
				item.Product.Size = size;
			}
			return View(favoriteProduct);
		}
	}
}
