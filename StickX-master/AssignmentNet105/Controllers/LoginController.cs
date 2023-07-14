using AssignmentNet105.IServices;
using AssignmentNet105.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;
using System;

namespace AssignmentNet105.Controllers
{
	[Route("api/login")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly IAccountService _accountService;

		public LoginController(IAccountService accountService)
		{
			_accountService = accountService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllAccounts()
		{
			var account = await _accountService.GetAllAccounts();
			return Ok(account);
		}
		[HttpGet("{id:Guid}")]
		public async Task<IActionResult> GetAccountById(Guid id)
		{
			var account = await _accountService.GetAccountById(id);
			JsonSerializerSettings settings = new JsonSerializerSettings
			{
				PreserveReferencesHandling = PreserveReferencesHandling.Objects
			};
			string json = JsonConvert.SerializeObject(account, settings);
			JToken parsedJson = JToken.Parse(json);
			string formattedJson = parsedJson.ToString(Formatting.Indented);
			return Ok(formattedJson);
		}
		[HttpPost]
		public async Task<bool> Login(LoginView account)
		{
			if (account == null) return false;
			bool checkAccount = await _accountService.Login(account);
			if(!checkAccount) return false;
			return true;
        }
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<UpdateAccount>> UpdateProduct(UpdateAccount account)
        {
            await _accountService.UpdateAccount(account);
            return Ok(account);
        }
    }
}
