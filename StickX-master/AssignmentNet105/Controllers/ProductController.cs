using AssignmentNet105.IServices;
using AssignmentNet105.Services;
using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;
using IdGen;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace AssignmentNet105.Controllers
{
	[Route("api/product")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}
		[HttpGet]
		public async Task<IActionResult> ShowListProduct()
		{
			var product = await _productService.ShowListProduct();
			return Ok(product);
		}
		[HttpGet("{id:Guid}")]
		public async Task<IActionResult> GetProductById([FromRoute] Guid id)
		{
			var product = await _productService.GetProductById(id);
			return Ok(product);
        }

        [HttpGet("{name}/{colorId:Guid}/{sizeId:Guid}")]
        public async Task<IActionResult> GetProductByCS(string name, Guid colorId, Guid sizeId)
        {
            var product = await _productService.GetProductByCS(name, colorId, sizeId);
            return Ok(product);
        }

        [HttpGet("{name}")]
		public async Task<IActionResult> GetProductByName([FromRoute] string name)
		{
			var product = await _productService.GetProductByName(name);
			return Ok(product);
		}
		[HttpPost]
		public async Task<ActionResult<Product>> CreateProduct(Product product)
		{
			await _productService.CreateProduct(product);
			return Ok(product);
		}
		[HttpPut("{id}")]
		public async Task<ActionResult<ProductView>> UpdateProduct(ProductView product)
		{
			await _productService.UpdateProduct(product);
			return Ok(product);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<Product>> DeleteProduct([FromRoute] Guid id)
		{
			await _productService.DeleteProduct(id);
			return Ok();
		}
	}
}
