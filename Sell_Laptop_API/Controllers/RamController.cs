using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public RamController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _dbContext.Rams.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult> Create(Ram ram)
        {
            try
            {
                await _dbContext.Rams.AddAsync(ram);
                await _dbContext.SaveChangesAsync();
                return Ok("Thêm thành công");
            }
            catch (Exception)
            {

                return BadRequest("Thất bại");
            }

        }
        [HttpPut("id")]
        public async Task<ActionResult> UpdateRam(Ram ram)
        {
            var r = _dbContext.Rams.Find(ram.Id);
            if (r == null)
            {
                return NotFound("Không tìm thấy");
            }
            else
            {
                try
                {
                    r.ThongSo = ram.ThongSo;
                    r.SoKheCam = ram.SoKheCam;
                    r.MoTa = ram.MoTa;
                    _dbContext.Rams.Update(r);
                    await _dbContext.SaveChangesAsync();
                    return Ok("Bạn đã cập nhật thành công");
                }
                catch (Exception)
                {

                    return BadRequest("Thất bại");
                }
            }

        }
        [HttpDelete("id")]
        public async Task<ActionResult> DeleteRam(Guid Id)
        {
            var r = _dbContext.Rams.Find(Id);
            if (r == null)
            {
                return NotFound("Không tìm thấy");
            }
            else
            {
                try
                {
                    _dbContext.Rams.Remove(r);
                    await _dbContext.SaveChangesAsync();
                    return Ok("Bạn đã xóa thành công");
                }
                catch (Exception)
                {
                    return BadRequest("Thất bại");
                }
            }
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ram = await _dbContext.Rams.FindAsync(id);
            return Ok(ram);
        }

    }
}

