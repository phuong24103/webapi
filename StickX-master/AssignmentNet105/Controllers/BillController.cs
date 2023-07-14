using AssignmentNet105.IServices;
using AssignmentNet105_Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using AssignmentNet105_Shared.ViewModels;
using AssignmentNet105.Services;
using IdGen;

namespace AssignmentNet105.Controllers
{
    [Route("api/bill")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService _ibillService;
        private readonly IBillDetailsService _ibillDetailsService;
        private readonly IProductService _iProductService;
        private readonly ICartDetailsService _iCartDetailsService;
        private readonly IAccountService _iAccountService;
        public BillController(IBillService billService, IBillDetailsService billDetailsService, IProductService iProductService, ICartDetailsService iCartDetailsService, IAccountService iAccountService)
        {
            _ibillService = billService;
            _ibillDetailsService = billDetailsService;
            _iProductService = iProductService;
            _iCartDetailsService = iCartDetailsService;
            _iAccountService = iAccountService;
        }
        [HttpGet]
        public async Task<IActionResult> ShowListBill()
        {
            var bill = await _ibillService.GetAllBills();
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };
            string json = JsonConvert.SerializeObject(bill, settings);
            JToken parsedJson = JToken.Parse(json);
            string formattedJson = parsedJson.ToString(Formatting.Indented);
            return Ok(formattedJson);
        }
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetBillByAccountId([FromRoute] Guid id)
        {
            var bill = await _ibillService.GetBillByAccountId(id);
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };
            string json = JsonConvert.SerializeObject(bill, settings);
            JToken parsedJson = JToken.Parse(json);
            string formattedJson = parsedJson.ToString(Formatting.Indented);
            return Ok(formattedJson);
        }

        [HttpPost]
        public async Task<ActionResult<Bill>> CreateBill(List<CartDetails> cartDetails)
        {
            Guid accountId = Guid.NewGuid();
            double price = 0;
            foreach (var item in cartDetails)
            {
                var product = _iProductService.GetProductById(item.ProductID);
                price += (product.Result.Price * item.Quantity);
                accountId = item.AccountID;
            }
            // Tạo một hóa đơn mới
            Bill bill = new Bill()
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                Status = 0,
                VoucherID = Guid.Parse("99fa04db-de10-4891-baf4-0188541db331"),
                Price = price,
                AccountID = accountId,
            };

            // Thêm hóa đơn vào danh sách
            await _ibillService.CreateBill(bill);

            foreach (var item in cartDetails)
            {
                var product = _iProductService.GetProductById(item.ProductID);
                product.Result.AvailableQuantity -= item.Quantity;
                await _iProductService.UpdateProduct(product.Result);

                // Tạo chi tiết hóa đơn mới
                BillDetails billDetail = new BillDetails()
                {
                    BillID = bill.Id,
                    ProductID = product.Result.Id,
                    Quantity = item.Quantity,
                    Prices = product.Result.Price * item.Quantity,
                };

                // Thêm chi tiết hóa đơn vào danh sách
                await _ibillDetailsService.CreateBillDetails(billDetail);
                await _iCartDetailsService.DeleteCartDetails(item.Id);
            }

            var account = _iAccountService.GetAccountById(accountId);
            if (price > 100000)
            {
                account.Result.Account.Point += (int) price / 10000;
                await _iAccountService.UpdateAccountPoint(account.Result);
            }

            return Ok(bill);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bill>> Delete(Guid id)
        {
            await _ibillService.DeleteBill(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<BillView>> Update(BillView billView)
        {
            await _ibillService.UpdateBill(billView);
            return Ok(billView);
        }
    }
}
