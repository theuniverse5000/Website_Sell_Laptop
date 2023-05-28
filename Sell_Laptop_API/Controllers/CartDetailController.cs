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
        private readonly IProductDetailServices _productDetailServices;

        public CartDetailController(ICartDetailServices cartDetailServices, IProductDetailServices productDetailServices)
        {
            _cartDetailServices = cartDetailServices;
            _productDetailServices = productDetailServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCartDetails()
        {
            var listCartDetail = await _cartDetailServices.GetCartDetailJoinProductDetail();
            return Ok(listCartDetail);

        }
        [Route("GetCartDetailNoJoin")]
        [HttpGet]
        public async Task<IActionResult> GetAllCartDetailNoJoin()
        {
            var listCartDetail = await _cartDetailServices.GetAllCartDetails();
            return Ok(listCartDetail);

        }
        [HttpPost]
        public async Task<IActionResult> CreateCartDetail(CartDetail obj)
        {
            var listCartDetail = await _cartDetailServices.GetAllCartDetails();
            var th = listCartDetail.FirstOrDefault(x => x.UserId == obj.UserId && x.IdProductDetails == obj.IdProductDetails);
            var productDetailx = _productDetailServices.GetProductDetailById(obj.IdProductDetails);
            if (productDetailx.Result.AvailableQuantity <= 0 || productDetailx.Result.AvailableQuantity < obj.Quantity)
            {
                return BadRequest("Số lượng sản phẩm không đủ");
            }
            if (th != null)
            {
                CartDetail oo = new CartDetail();
                oo.Id = th.Id;
                oo.Quantity = (th.Quantity + obj.Quantity);
                await _cartDetailServices.UpdateCartDetail(oo);
                return Ok("Sản phẩm đã tồn tại. Số lượng vừa được cập nhât");
            }

            if (await _cartDetailServices.CreateCartDetail(obj))
            {
                return Ok("Bạn thêm thành công");
            }
            return BadRequest("Không thành công !");

        }

        [Route("UpdateQuantity")]
        [HttpPut]
        public async Task<IActionResult> UpdateCartDetail(CartDetail obj)
        {
            if (await _cartDetailServices.UpdateCartDetail(obj))
            {
                return Ok("Thành công");
            }
            else
            {
                return BadRequest("Không thành công !");
            }

        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCartDetail(Guid id)
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
        public async Task<IActionResult> GetCartDetailById(Guid id)
        {
            var cartDetail = await _cartDetailServices.GetCartDetailById(id);
            return Ok(cartDetail);
        }
    }
}
