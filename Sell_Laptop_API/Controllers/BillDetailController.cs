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
        private readonly IProductDetailServices _productDetailServices;
        public BillDetailController(IBillDetailServices billDetailServices, IProductDetailServices productDetailServices)
        {
            _billDetailServices = billDetailServices;

            _productDetailServices = productDetailServices;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllBillDetails()
        {
            var listBillDetail = await _billDetailServices.GetAllBillDetails();
            return Ok(listBillDetail);

        }
        [HttpPost]
        public async Task<IActionResult> CreateBillDetail(BillDetail obj)
        {
            var listBillDetail = await _billDetailServices.GetAllBillDetails();
            var th = listBillDetail.FirstOrDefault(x => x.IdBill == obj.IdBill && x.IdProductDetails == obj.IdProductDetails);
            var productDetailx = _productDetailServices.GetProductDetailById(obj.IdProductDetails);
            if (productDetailx.Result.AvailableQuantity <= 0 || productDetailx.Result.AvailableQuantity < obj.Quantity)
            {
                return BadRequest("Số lượng sản phẩm không đủ");
            }
            if (th != null)
            {
                BillDetail oo = new BillDetail();
                oo.Id = th.Id;
                // oo.Price = obj.Price;
                oo.Quantity = (th.Quantity + obj.Quantity);
                await _billDetailServices.UpdateBillDetail(oo);
                return Ok("Sản phẩm đã tồn tại. Số lượng vừa được cập nhât");
            }
            else if (await _billDetailServices.CreateBillDetail(obj))
            {
                return Ok("Bạn thêm thành công");
            }
            return BadRequest("Không thành công !");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateBillDetail(BillDetail obj)
        {
            if (obj != null)
            {
                if (await _billDetailServices.UpdateBillDetail(obj))
                {
                    return Ok("Bạn update thành công");
                }
                return BadRequest("Không thành công !");
            }
            else
            {
                return BadRequest("Không tồn tại");
            }
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteBillDetail(Guid id)
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
        public async Task<IActionResult> GetBillDetailById(Guid id)
        {
            var billDetail = await _billDetailServices.GetBillDetailById(id);
            return Ok(billDetail);
        }
    }
}
