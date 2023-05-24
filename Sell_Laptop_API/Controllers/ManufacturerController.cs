using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public ManufacturerController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _dbContext.Manufacturers.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Manufacturer obj)
        {
            var listManufacturer = await _dbContext.Manufacturers.ToListAsync();
            var t = listManufacturer.FirstOrDefault(x => x.Name == obj.Name);
            if (t != null)
            {
                return BadRequest("Thất bại. Tên đã tồn tại");
            }
            else
            {
                try
                {
                    await _dbContext.Manufacturers.AddAsync(obj);
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
        public async Task<IActionResult> Update(Manufacturer obj)
        {
            try
            {
                var l = await _dbContext.Manufacturers.FindAsync(obj.Id);
                _dbContext.Manufacturers.Update(l);
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
                var t = await _dbContext.Manufacturers.FindAsync(id);
                _dbContext.Manufacturers.Remove(t);
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
            var manufacturer = await _dbContext.Manufacturers.FindAsync(id);
            return Ok(manufacturer);
        }
    }
}
