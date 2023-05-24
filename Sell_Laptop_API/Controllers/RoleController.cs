using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public RoleController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _dbContext.Roles.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Role obj)
        {
            var listRole = await _dbContext.Roles.ToListAsync();
            var t = listRole.FirstOrDefault(x => x.RoleName == obj.RoleName);
            if (t != null)
            {
                return BadRequest("Thất bại. Chức vụ đã tồn tại");
            }
            else
            {
                try
                {
                    await _dbContext.Roles.AddAsync(obj);
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
        public async Task<IActionResult> Update(Role obj)
        {
            try
            {
                var l = await _dbContext.Roles.FindAsync(obj.Id);
                l.Description = obj.Description;
                l.Status = obj.Status;
                _dbContext.Roles.Update(l);
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
                var t = await _dbContext.Roles.FindAsync(id);
                _dbContext.Roles.Remove(t);
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
            var role = await _dbContext.Roles.FindAsync(id);
            return Ok(role);
        }
    }
}
