	using AssignmentNet105.IServices;
using AssignmentNet105.Services;
using AssignmentNet105_Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentNet105.Controllers
{
	[Route("api/color")]
	[ApiController]
	public class ColorController : ControllerBase
	{
		private readonly IColorService _colorService;

		public ColorController(IColorService colorService)
		{
			_colorService = colorService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllColor()
		{
			var color = await _colorService.GetAllColor();
			return Ok(color);
        }
		[HttpGet("{id:Guid}")]
		public async Task<IActionResult> GetColorById(Guid id)
		{
			var color = await _colorService.GetColorById(id);
			return Ok(color);
		}
		[HttpGet("{name}")]
		public async Task<IActionResult> GetColorByName(string name)
		{
			var color = await _colorService.GetColorByName(name);
			return Ok(color);
		}
		[HttpPost]
        public async Task<ActionResult<Color>> CreateColor(Color color)
        {
            await _colorService.CreateColor(color);
            return Ok(color);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Color>> UpdateNhanVien(Color color)
        {
            await _colorService.UpdateColor(color);
            return Ok(color);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Color>> DeleteColor(Guid id)
        {
            await _colorService.DeleteColor(id);
            return Ok();
        }
    }
}
