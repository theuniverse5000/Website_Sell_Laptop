using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardDriveController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public HardDriveController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _dbContext.HardDrives.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(HardDrive obj)
        {
            var listHardDrive = await _dbContext.HardDrives.ToListAsync();
            var t = listHardDrive.FirstOrDefault(x => x.Ma == obj.Ma);
            if (t != null)
            {
                return BadRequest("Thất bại. Mã đã tồn tại");
            }
            else
            {
                try
                {
                    await _dbContext.HardDrives.AddAsync(obj);
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
        public async Task<IActionResult> Update(HardDrive obj)
        {
            try
            {
                var l = await _dbContext.HardDrives.FindAsync(obj.Id);
                l.MoTa = obj.MoTa;
                l.ThongSo = obj.ThongSo;
                _dbContext.HardDrives.Update(l);
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
                var t = await _dbContext.HardDrives.FindAsync(id);
                _dbContext.HardDrives.Remove(t);
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
            var hardDrive = await _dbContext.HardDrives.FindAsync(id);
            return Ok(hardDrive);
        }
    }
}
