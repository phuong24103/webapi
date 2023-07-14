using AssignmentNet105.IServices;
using AssignmentNet105.Services;
using AssignmentNet105_Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Routing;
using IdGen;
using Microsoft.AspNetCore.Cors;

namespace AssignmentNet105.Controllers
{
	[Route("api/favoriteProducts")]
	[ApiController]
	public class FavoriteProductsController : ControllerBase
	{
		private readonly IFavoriteProductsService _favoriteProductService;

		public FavoriteProductsController(IFavoriteProductsService favoriteProductService)
		{
			_favoriteProductService = favoriteProductService;
		}
		[HttpGet("{id:Guid}")]
		public async Task<IActionResult> GetFavoriteProductsByAccount(Guid id)
		{
			var favoriteProduct = await _favoriteProductService.GetFavoriteProductsByAccount(id);
			JsonSerializerSettings settings = new JsonSerializerSettings
			{
				PreserveReferencesHandling = PreserveReferencesHandling.Objects
			};
			string json = JsonConvert.SerializeObject(favoriteProduct, settings);
			JToken parsedJson = JToken.Parse(json);
			string formattedJson = parsedJson.ToString(Formatting.Indented);
			return Ok(formattedJson);
		}
		[HttpOptions("{accountId}/{productId}")]
		public async Task<ActionResult<FavoriteProducts>> Like(Guid accountId, Guid productId)
        {
            await _favoriteProductService.Like(accountId, productId);
            var favoriteProduct = await _favoriteProductService.GetFavoriteProduct(accountId, productId);
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };
            string json = JsonConvert.SerializeObject(favoriteProduct, settings);
            JToken parsedJson = JToken.Parse(json);
            string formattedJson = parsedJson.ToString(Formatting.Indented);
            return Ok(formattedJson);
		}
	}
}
