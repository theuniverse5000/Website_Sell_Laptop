using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public ImageController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            return Ok(await _dbContext.Images.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> CreateImage(Image obj)
        {
            var listImage = await _dbContext.Images.ToListAsync();
            var t = listImage.FirstOrDefault(x => x.Ma == obj.Ma);
            if (t != null)
            {
                return BadRequest("Thất bại. Mã đã tồn tại");
            }
            else
            {
                try
                {
                    obj.Id = Guid.NewGuid();
                    await _dbContext.Images.AddAsync(obj);
                    await _dbContext.SaveChangesAsync();
                    return Ok("Thành công");
                }
                catch (Exception)
                {
                    return BadRequest("Thất bại");
                }
            }

        }
        [HttpPut]
        public async Task<IActionResult> UpdateImage(Image obj)
        {
            try
            {
                var l = await _dbContext.Images.FindAsync(obj.Id);
                l.LinkImage = obj.LinkImage;
                _dbContext.Images.Update(l);
                await _dbContext.SaveChangesAsync();
                return Ok("Thành công");
            }
            catch (Exception)
            {
                return BadRequest("Thất bại");
            }
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteImage(Guid id)
        {
            try
            {
                var t = await _dbContext.Images.FindAsync(id);
                _dbContext.Images.Remove(t);
                await _dbContext.SaveChangesAsync();
                return Ok("Bạn đã xóa thành công");
            }
            catch (Exception)
            {
                return BadRequest("Thất bại");
            }
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetImageById(Guid id)
        {
            var image = await _dbContext.Images.FindAsync(id);
            return Ok(image);
        }
    }
}
