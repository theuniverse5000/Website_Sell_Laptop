﻿using Data.Models;
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
        public async Task<IActionResult> GetAllProductDetails()
        {
            var listProductDetail = await _productDetailServices.GetAllProductDetailsPhunData();
            return Ok(listProductDetail);

        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(ProductDetail obj)
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
        public async Task<IActionResult> UpdateProductDetail(ProductDetail obj)
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
        public async Task<IActionResult> DeleteProductDetail(Guid id)
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
        public async Task<IActionResult> GetProductDetailById(Guid id)
        {
            var listProductDetail = await _productDetailServices.GetAllProductDetailsPhunData();
            var productDetail = listProductDetail.FirstOrDefault(x => x.Id == id);
            return Ok(productDetail);
        }
    }
}
