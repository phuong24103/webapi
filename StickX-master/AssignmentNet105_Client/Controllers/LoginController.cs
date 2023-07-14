using AssignmentNet105_Client.Services;
using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Principal;
using System.Text;

namespace AssignmentNet105_Client.Controllers
{
	public class LoginController : Controller
	{
		TServices _services = new TServices();
		public IActionResult Login()
		{
			return View();
        }
        public async Task<IActionResult> GetAccountById()
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            return View(await _services.GetAllById<AccountView>($"https://localhost:7197/api/login/{user.Id}"));
        }
        [HttpPost]
		public async Task<IActionResult> Login(LoginView account)
		{
			if (account.UserName != null && account.PassWord != null)
			{
				HttpClient httpClient = new HttpClient(); // tạo ra để callApi
														  // Convert registerUser to JSON
				var loginUserJSON = JsonConvert.SerializeObject(account);

				// Convert to string content
				var stringContent = new StringContent(loginUserJSON, Encoding.UTF8, "application/json");

				// Send request POST to register API
				var response = await httpClient.PostAsync($"https://localhost:7197/api/login", stringContent);
				var check = await response.Content.ReadAsStringAsync();
				bool checkAccount = Convert.ToBoolean(check);
				if (checkAccount)
				{
					var a = await _services.GetAll<Account>("https://localhost:7197/api/login");
					var result = a.FirstOrDefault(p => p.UserName == account.UserName);
					SessionServices.SetAccountToSession(HttpContext.Session, "User", result);
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", "Invalid Username or Password");
				}
			}
			return View();
		}
		public async Task<IActionResult> Logout()
		{
			Account a = new Account() { Status = 404 };
			SessionServices.SetAccountToSession(HttpContext.Session, "User", a);
			return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)//Mở form
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
			UpdateAccount acc = new UpdateAccount();
			acc.Id = id;
			acc.UserName = user.UserName;
			acc.DateOfBirth = DateTime.Now;
			acc.Gender = user.Gender;
			acc.PhoneNumber = user.PhoneNumber;
			acc.Email = user.Email;
			acc.Address = user.Address;
            return View(acc);
        }
        public async Task<IActionResult> Edit(UpdateAccount account)
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            await _services.EditAll($"https://localhost:7197/api/login/{account.Id}", account);
            return RedirectToAction("Index", "Home");
        }
    }
}
