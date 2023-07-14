using AssignmentNet105.IServices;
using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;

namespace AssignmentNet105.Controllers
{
	[Route("api/cart")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private readonly ICartService _icartService;
		public CartController(ICartService icartService)
		{
			_icartService = icartService;
		}
		[HttpGet]
		public async Task<IActionResult> ShowListCart()
		{
			var cart = await _icartService.GetAllCart();
			JsonSerializerSettings settings = new JsonSerializerSettings
			{
				PreserveReferencesHandling = PreserveReferencesHandling.Objects
			};
			string json = JsonConvert.SerializeObject(cart, settings);
			JToken parsedJson = JToken.Parse(json);
			string formattedJson = parsedJson.ToString(Formatting.Indented);
			return Ok(formattedJson);

		}
		[HttpGet("{id:Guid}")]
		public async Task<IActionResult> GetCartById([FromRoute] Guid id)
		{
			var cart = await _icartService.GetCartById(id);
			JsonSerializerSettings settings = new JsonSerializerSettings
			{
				PreserveReferencesHandling = PreserveReferencesHandling.Objects
			};
			string json = JsonConvert.SerializeObject(cart, settings);
			JToken parsedJson = JToken.Parse(json);
			string formattedJson = parsedJson.ToString(Formatting.Indented);
			return Ok(formattedJson);
		}
		[HttpPost]
		public async Task<ActionResult<Cart>> Create(Cart cart)
		{
			await _icartService.CreateCart(cart);
			return Ok(cart);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<Cart>> Delete(Guid id)
		{
			await _icartService.DeleteCart(id);
			return Ok();
		}
		[HttpPut("{id}")]
		public async Task<ActionResult<CartView>> Update (CartView cartview)
		{
			await _icartService.UpdateCart(cartview);
			return Ok(cartview);
		}
	}
}
