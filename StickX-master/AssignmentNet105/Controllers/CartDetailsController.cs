using AssignmentNet105.IServices;
using AssignmentNet105.Services;
using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AssignmentNet105.Controllers
{
	[Route("api/cartdetails")]
	[ApiController]
	public class CartDetailsController : ControllerBase
	{
		private readonly ICartDetailsService _cartDetailsService;

		public CartDetailsController(ICartDetailsService cartDetailsService)
		{
			_cartDetailsService = cartDetailsService;
		}
		[HttpGet]
		public async Task<IActionResult> ShowListCartDetails()
		{
			var cartdt = await _cartDetailsService.GetAllCartDetails();
			JsonSerializerSettings settings = new JsonSerializerSettings
			{
				PreserveReferencesHandling = PreserveReferencesHandling.Objects
			};
			string json = JsonConvert.SerializeObject(cartdt, settings);
			JToken parsedjson = JToken.Parse(json);
			string formattedJson = parsedjson.ToString(Formatting.Indented);
			return Ok(formattedJson);
		}
		[HttpGet("{id:Guid}")]
		public async Task<IActionResult> GetCartDetailsByAccountId([FromRoute] Guid id)
		{
			var cartdt = await _cartDetailsService.GetCartDetailsByAccountId(id);
			JsonSerializerSettings settings = new JsonSerializerSettings
			{
				PreserveReferencesHandling = PreserveReferencesHandling.Objects
			};
			string json = JsonConvert.SerializeObject(cartdt, settings);
			JToken parsedjson = JToken.Parse(json);
			string formattedJson = parsedjson.ToString(Formatting.Indented);
			return Ok(formattedJson);
		}
		[HttpGet("GetById/{accountId:Guid}/{productId:Guid}")]
		public async Task<IActionResult> GetCartDetailsById(Guid accountId, Guid productId)
		{
			var cartdt = await _cartDetailsService.GetCartDetailsById(accountId, productId);
			JsonSerializerSettings settings = new JsonSerializerSettings
			{
				PreserveReferencesHandling = PreserveReferencesHandling.Objects
			};
			string json = JsonConvert.SerializeObject(cartdt, settings);
			JToken parsedjson = JToken.Parse(json);
			string formattedJson = parsedjson.ToString(Formatting.Indented);
			return Ok(formattedJson);
		}

		[HttpPost("{accountId:Guid}/{productId:Guid}")]
		public async Task<ActionResult<CartDetails>> CreateCartDetails(Guid accountId, Guid productId)
        {
			await _cartDetailsService.CreateCartDetails(accountId, productId);
			return Ok();
		}

		[HttpPut("Increase/{id}")]
		public async Task<ActionResult<CartDetails>> Increase(Guid id)
		{
			await _cartDetailsService.Increase(id);
			return Ok();
		}

		[HttpPut("Reduce/{id}")]
		public async Task<ActionResult<CartDetails>> Reduce(Guid id)
        {
            await _cartDetailsService.Reduce(id);
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<CartDetailsView>> DeleteCartDetails(Guid id)
		{
			await _cartDetailsService.DeleteCartDetails(id);
			return Ok();
		}
	}
}
