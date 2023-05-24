using Data.Models;
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
        [HttpGet]
        public async Task<ActionResult> GetAllBillDetails()
        {
            var listBillDetail = await _billDetailServices.GetAllBillDetails();
            return Ok(listBillDetail);

        }
        [HttpPost]
        public async Task<ActionResult> CreateBillDetail(BillDetail obj)
        {
            if (obj != null)
            {
                if (await _billDetailServices.CreateBillDetail(obj))
                {
                    return Ok("Bạn thêm thành công");
                }
                return BadRequest("Không thành công !");
            }
            else
            {
                return BadRequest("Không tồn tại");
            }
        }
        [HttpPut("id")]
        public async Task<ActionResult> UpdateBillDetail(BillDetail obj)
        {
            if (obj != null)
            {
                if (await _billDetailServices.UpdateBillDetail(obj))
                {
                    return Ok("Thành công");
                }
                return BadRequest("Không thành công !");
            }
            else
            {
                return BadRequest("Không tồn tại");
            }
        }
        [HttpDelete("id")]
        public async Task<ActionResult> DeleteBillDetail(Guid id)
        {
            if (await _billDetailServices.DeleteBillDetail(id))
            {
                return Ok("Bạn đã xóa thành công");
            }
            else
            {
                return BadRequest("Thất bại");
            }
        }
        [HttpGet("id")]
        public async Task<ActionResult> GetBillDetailById(Guid id)
        {
            var billDetail = await _billDetailServices.GetBillDetailById(id);
            return Ok(billDetail);
        }
    }
}
