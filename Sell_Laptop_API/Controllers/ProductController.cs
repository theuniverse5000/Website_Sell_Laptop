using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _dbContext.Products.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product obj)
        {
            var listProduct = await _dbContext.Products.ToListAsync();
            var t = listProduct.FirstOrDefault(x => x.Name == obj.Name);
            if (t != null)
            {
                return BadRequest("Thất bại. Tên đã tồn tại");
            }
            else
            {
                try
                {
                    await _dbContext.Products.AddAsync(obj);
                    await _dbContext.SaveChangesAsync();
                    return Ok("Thành công");
                }
                catch (Exception)
                {
                    return BadRequest("Thất bại");
                }
            }

        }
        [HttpPut("id")]
        public async Task<IActionResult> Update(Product obj)
        {
            try
            {
                var l = await _dbContext.Products.FindAsync(obj.Id);
                _dbContext.Products.Update(l);
                await _dbContext.SaveChangesAsync();
                return Ok("Thành công");
            }
            catch (Exception)
            {
                return BadRequest("Thất bại");
            }
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var t = await _dbContext.Products.FindAsync(id);
                _dbContext.Products.Remove(t);
                await _dbContext.SaveChangesAsync();
                return Ok("Bạn đã xóa thành công");
            }
            catch (Exception)
            {
                return BadRequest("Thất bại");
            }
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            return Ok(product);
        }
    }
}
