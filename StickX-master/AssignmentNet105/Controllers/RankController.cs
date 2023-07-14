using AssignmentNet105.IServices;
using AssignmentNet105_Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentNet105.Controllers
{
	[Route("api/rank")]
	[ApiController]
	public class RankController : ControllerBase
	{
		private readonly IRankService _rankService;

		public RankController(IRankService rankService)
		{
			_rankService = rankService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllRank()
		{
			var rank = await _rankService.GetAllRank();
			return Ok(rank);
		}
		[HttpGet("{id:Guid}")]
		public async Task<ActionResult> GetRankById(Guid id)
		{
			var rank = await _rankService.GetRankById(id);
			return Ok(rank);
		}
		[HttpGet("{name}")]
		public async Task<IActionResult> GetRankByName(string name)
		{
			var rank = await _rankService.GetRankByName(name);
			return Ok(rank);
		}
		[HttpPost]
		public async Task<ActionResult<Rank>> CreateRank(Rank rank)
		{
			await _rankService.CreateRank(rank);
			return Ok(rank);
		}
		[HttpPut("{id}")]
		public async Task<ActionResult<Rank>> UpdateRank(Rank rank)
		{
			await _rankService.UpdateRank(rank);
			return Ok(rank);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<Rank>> DeleteRank(Guid id)
		{
			await _rankService.DeleteRank(id);
			return Ok();
		}
	}
}
