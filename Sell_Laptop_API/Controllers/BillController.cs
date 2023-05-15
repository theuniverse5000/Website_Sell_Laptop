using Data.Models;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillServices _billServices;
        public BillController(IBillServices billServices)
        {
            _billServices = billServices;
        }
        [HttpGet]
        public async Task<ActionResult> GetBill()
        {
            var listBill = await _billServices.GetAllBills();
            return Ok(listBill);

        }
        [HttpPost]
        public async Task<ActionResult> CreateBill(Bill obj)
        {
            if (obj != null)
            {
                if (await _billServices.CreateBill(obj))
                {
                    return Ok("Bạn thêm thành công");
                }
                return BadRequest("Không thành công !");
            }
            else
            {
                return BadRequest("Hóa đơn không tồn tại");
            }
        }
    }
}
