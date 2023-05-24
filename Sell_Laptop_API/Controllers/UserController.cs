using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public UserController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _dbContext.Users.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(User obj)
        {
            var listUser = await _dbContext.Users.ToListAsync();
            var t = listUser.FirstOrDefault(x => x.Username == obj.Username);
            if (t != null)
            {
                return BadRequest("Thất bại. Tài khoản đã tồn tại");
            }
            else
            {
                try
                {
                    await _dbContext.Users.AddAsync(obj);
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
        public async Task<IActionResult> Update(User obj)
        {
            try
            {
                var l = await _dbContext.Users.FindAsync(obj.Id);
                l.Password = obj.Password;
                l.Status = obj.Status;
                _dbContext.Users.Update(l);
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
                var t = await _dbContext.Users.FindAsync(id);
                _dbContext.Users.Remove(t);
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
            var user = await _dbContext.Users.FindAsync(id);
            return Ok(user);
        }
    }
}
