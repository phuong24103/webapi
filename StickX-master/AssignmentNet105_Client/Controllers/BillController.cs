using AssignmentNet105_Client.Services;
using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace AssignmentNet105_Client.Controllers
{
    public class BillController : Controller
    {
        TServices _services = new TServices();

        public async Task<IActionResult> Index()
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            return View(await _services.GetAll<BillView>($"https://localhost:7197/api/bill/{user.Id}"));
        }

        [Route("[action]")]
        public async Task<IActionResult> Create()
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
                var result = await _services.GetAll<CartDetailsView>($"https://localhost:7197/api/cartdetails/{user.Id}");
                List<CartDetails> cartDetails = new List<CartDetails>(result.Count());
                for (int i = 0; i < result.Count(); i++)
                {
                    var details = new CartDetails();
                    details.Id = result[i].CartDetails.Id;
                    details.Quantity = result[i].CartDetails.Quantity;
                    details.AccountID = result[i].CartDetails.AccountID;
                    details.ProductID = result[i].CartDetails.ProductID;
                    cartDetails.Add(details);
                }
                await _services.CreateAll("https://localhost:7197/api/bill", cartDetails);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Login");
        }

        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            await _services.DeleteAll<Bill>($"https://localhost:7197/api/bill/{id}");
            return RedirectToAction("Index");
        }
        [Route("[action]/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            var bill = await _services.GetAllById<Bill>($"https://localhost:7197/api/bill/{id}");
            return View(bill);
        }
        public async Task<IActionResult> Edit(Bill bill)
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            await _services.EditAll($"https://localhost:7197/api/{bill.Id}", bill);
            return RedirectToAction("Index");
        }

    }
}
