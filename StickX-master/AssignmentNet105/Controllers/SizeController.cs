using AssignmentNet105.IServices;
using AssignmentNet105_Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentNet105.Controllers
{
    [Route("api/size")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSize()
        {
            var size = await _sizeService.GetAllSize();
            return Ok(size);
        }
        [HttpPost]
        public async Task<ActionResult<Size>> CreateSize(Size size)
        {
            await _sizeService.CreateSize(size);
            return Ok(size);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Size>> UpdateSize(Size size)
        {
            await _sizeService.UpdateSize(size);
            return Ok(size);
        }
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetSizeById(Guid id)
        {
            var getid = await _sizeService.GetSizeById(id);
            return Ok(getid);
        }
        [HttpGet("{name}")]
        public async Task <IActionResult> GetSizeByName(string name)
        {
            var namesize = await _sizeService.GetSizeByName(name);
            return Ok(namesize);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSize(Guid id)
        {
            var delsize = _sizeService.DeleteSize(id);
            return Ok(delsize);
        }
    }
}
