using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillDetailController : ControllerBase
    {
        private readonly IBillDetailServices _billDetailServices;
        public BillDetailController(IBillDetailServices billDetailServices)
        {
            _billDetailServices = billDetailServices;
        }
        //[HttpGet]
        //public async Task<ActionResult> GetBillDetail()
        //{
        //    listBillDetail = await _billDetailServices.GetAllBillDetails();
        //    return Ok(_billDetailServices.GetAllBillDetails());
        //}
    }
}
