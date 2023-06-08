using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public CpuController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCpu()
        {
            return Ok(await _dbContext.Cpus.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> CreateCpu(Cpu obj)
        {
            var listCpu = await _dbContext.Cpus.ToListAsync();
            var t = listCpu.FirstOrDefault(x => x.Ma == obj.Ma);
            if (t != null)
            {
                return BadRequest("Thất bại. Mã đã tồn tại");
            }
            else
            {
                try
                {
                    obj.Id = Guid.NewGuid();
                    await _dbContext.Cpus.AddAsync(obj);
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
        public async Task<IActionResult> UpdateCpu(Cpu obj)
        {
            try
            {
                var t = await _dbContext.Cpus.FindAsync(obj.Id);
                t.Name = obj.Name;
                t.ThongSo = obj.ThongSo;
                _dbContext.Cpus.Update(t);
                await _dbContext.SaveChangesAsync();
                return Ok("Thành công");
            }
            catch (Exception)
            {
                return BadRequest("Thất bại");
            }
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCpu(Guid id)
        {
            try
            {
                var t = await _dbContext.Cpus.FindAsync(id);
                _dbContext.Cpus.Remove(t);
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
            var cpu = await _dbContext.Cpus.FindAsync(id);
            return Ok(cpu);
        }
    }
}
