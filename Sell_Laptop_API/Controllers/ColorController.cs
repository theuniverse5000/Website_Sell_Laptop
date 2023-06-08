using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public ColorController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllColors()
        {
            return Ok(await _dbContext.Colors.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> CreateColor(Color obj)
        {
            var listColor = await _dbContext.Colors.ToListAsync();
            var t = listColor.FirstOrDefault(x => x.Ma == obj.Ma);
            if (t != null)
            {
                return BadRequest("Thất bại. Mã đã tồn tại");
            }
            else
            {
                try
                {
                    await _dbContext.Colors.AddAsync(obj);
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
        public async Task<IActionResult> UpdateColor(Color obj)
        {
            try
            {
                var l = await _dbContext.Colors.FindAsync(obj.Id);
                l.Name = obj.Name;
                _dbContext.Colors.Update(l);
                await _dbContext.SaveChangesAsync();
                return Ok("Thành công");
            }
            catch (Exception)
            {
                return BadRequest("Thất bại");
            }
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteColor(Guid id)
        {
            try
            {
                var t = await _dbContext.Colors.FindAsync(id);
                _dbContext.Colors.Remove(t);
                await _dbContext.SaveChangesAsync();
                return Ok("Bạn đã xóa thành công");
            }
            catch (Exception)
            {
                return BadRequest("Thất bại");
            }
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetColorById(Guid id)
        {
            var Color = await _dbContext.Colors.FindAsync(id);
            return Ok(Color);
        }
    }
}
