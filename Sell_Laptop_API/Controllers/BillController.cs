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
        public async Task<ActionResult> GetAllBills()
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
        [HttpPut("id")]
        public async Task<ActionResult> UpdateBill(Bill obj)
        {
            if (obj != null)
            {
                if (await _billServices.UpdateBill(obj))
                {
                    return Ok("Thành công");
                }
                return BadRequest("Không thành công!");
            }
            else
            {
                return BadRequest("Thất bại");
            }
        }
        [HttpDelete("id")]
        public async Task<ActionResult> DeleteBill(Guid id)
        {
            if (await _billServices.DeleteBill(id))
            {
                return Ok("Bạn đã xóa thành công");
            }
            else
            {
                return BadRequest("Thất bại");
            }
        }
        [HttpGet("id")]
        public async Task<ActionResult> GetBillById(Guid id)
        {
            var bill = await _billServices.GetBillById(id);
            return Ok(bill);
        }
    }
}
