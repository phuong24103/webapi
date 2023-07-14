using AssignmentNet105.IServices;
using AssignmentNet105_Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentNet105.Controllers
{
	[Route("api/register")]
	[ApiController]
	public class RegisterController : ControllerBase
	{
		private readonly IAccountService _accountService;

		public RegisterController(IAccountService accountService)
		{
			_accountService = accountService;
		}
		[HttpPost]
		public async Task<ActionResult<Account>> Register(Account account)
		{
			await _accountService.Register(account);
			return Ok(account);
		}
	}
}
