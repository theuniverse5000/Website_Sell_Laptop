using Data.Models;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartDetailController : ControllerBase
    {
        private readonly ICartDetailServices _cartDetailServices;
        public CartDetailController(ICartDetailServices cartDetailServices)
        {
            _cartDetailServices = cartDetailServices;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllCartDetails()
        {
            var listCartDetail = await _cartDetailServices.GetAllCartDetails();
            return Ok(listCartDetail);

        }
        [HttpPost]
        public async Task<ActionResult> CreateCartDetail(CartDetail obj)
        {
            if (obj != null)
            {
                if (await _cartDetailServices.CreateCartDetail(obj))
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
        public async Task<ActionResult> UpdateCartDetail(CartDetail obj)
        {
            if (obj != null)
            {
                if (await _cartDetailServices.UpdateCartDetail(obj))
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
        public async Task<ActionResult> DeleteCartDetail(Guid id)
        {
            if (await _cartDetailServices.DeleteCartDetail(id))
            {
                return Ok("Bạn đã xóa thành công");
            }
            else
            {
                return BadRequest("Thất bại");
            }
        }
        [HttpGet("id")]
        public async Task<ActionResult> GetCartDetailById(Guid id)
        {
            var cartDetail = await _cartDetailServices.GetCartDetailById(id);
            return Ok(cartDetail);
        }
    }
}
