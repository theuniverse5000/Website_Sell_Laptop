using Data.Models;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailServices _productDetailServices;
        public ProductDetailController(IProductDetailServices productDetailServices)
        {
            _productDetailServices = productDetailServices;
        }
        [HttpGet]
        //[Route("get-all-")]
        public async Task<ActionResult> GetAllProductDetails()
        {
            var listProductDetail = await _productDetailServices.GetAllProductDetailsPhunData();
            return Ok(listProductDetail);

        }
        [HttpPost]
        public async Task<ActionResult> CreateProductDetail(ProductDetail obj)
        {
            if (obj != null)
            {
                if (await _productDetailServices.IsMaProductDetailExist(obj.Ma))
                {
                    return BadRequest("Mã đã tồn tại !");
                }
                if (await _productDetailServices.CreateProductDetail(obj))
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
        public async Task<ActionResult> UpdateProductDetail(ProductDetail obj)
        {
            if (obj != null)
            {
                if (await _productDetailServices.UpdateProductDetail(obj))
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
        public async Task<ActionResult> DeleteProductDetail(Guid id)
        {
            if (await _productDetailServices.DeleteProductDetail(id))
            {
                return Ok("Bạn đã xóa thành công");
            }
            else
            {
                return BadRequest("Thất bại");
            }
        }
        [HttpGet("id")]
        public async Task<ActionResult> GetProductDetailById(Guid id)
        {
            var productDetail = await _productDetailServices.GetProductDetailById(id);
            return Ok(productDetail);
        }
    }
}
