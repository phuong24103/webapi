using AssignmentNet105.IServices;
using AssignmentNet105.Services;
using AssignmentNet105_Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using AssignmentNet105_Shared.ViewModels;

namespace AssignmentNet105.Controllers
{
    [Route("api/billdetails")]
    [ApiController]
    public class BillDetailsController : ControllerBase
    {
        private readonly IBillDetailsService _billDetailsService;
        public BillDetailsController(IBillDetailsService billDetailsService)
        {
            _billDetailsService = billDetailsService;
        }
        [HttpGet]
        public async Task<IActionResult> ShowListBillDetails()
        {
            var billdt = await _billDetailsService.GetAllBillDetails();
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };
            string json = JsonConvert.SerializeObject(billdt, settings);
            JToken parsedJson = JToken.Parse(json);
            string formattedJson = parsedJson.ToString(Formatting.Indented);
            return Ok(formattedJson);
        }
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetBillDetailsByBillId([FromRoute] Guid id)
        {
            var billdt = await _billDetailsService.GetBillDetailsByBillId(id);
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };
            string json = JsonConvert.SerializeObject(billdt, settings);
            JToken parsedJson = JToken.Parse(json);
            string formattedJson = parsedJson.ToString(Formatting.Indented);
            return Ok(formattedJson);
        }
        [HttpPost]
        public async Task<ActionResult<BillDetails>> CreateBillDetails(BillDetails billDetails)
        {
            await _billDetailsService.CreateBillDetails(billDetails);
            return Ok(billDetails);
        }
        [HttpPut("{id}")]
		public async Task<ActionResult<BillDetailsView>> UpdateBillDetails(BillDetailsView billDetails)
		{
			await _billDetailsService.UpdateBillDetails(billDetails);
			return Ok(billDetails);
		}
        [HttpDelete("{id}")]
        public async Task<ActionResult<BillDetailsView>> DeleteBillDetails([FromRoute] Guid id)
        {
            await _billDetailsService.DeleteBillDetails(id);
            return Ok();
        }
    }

}
