using Data.Models;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartServices _cartServices;
        public CartController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllCarts()
        {
            var listCart = await _cartServices.GetAllCarts();
            return Ok(listCart);

        }
        [HttpPost]
        public async Task<ActionResult> CreateCart(Cart obj)
        {
            if (obj != null)
            {
                if (await _cartServices.CreateCart(obj))
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
        [HttpPut]
        public async Task<ActionResult> UpdateCart(Cart obj)
        {
            if (obj != null)
            {
                if (await _cartServices.UpdateCart(obj))
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
        public async Task<ActionResult> DeleteCart(Guid id)
        {
            if (await _cartServices.DeleteCart(id))
            {
                return Ok("Bạn đã xóa thành công");
            }
            else
            {
                return BadRequest("Thất bại");
            }
        }
        [HttpGet("id")]
        public async Task<ActionResult> GetCartById(Guid id)
        {
            var cart = await _cartServices.GetCartById(id);
            return Ok(cart);
        }
    }
}
