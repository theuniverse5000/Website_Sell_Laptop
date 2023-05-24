using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public VoucherController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _dbContext.Vouchers.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Voucher obj)
        {
            var listVoucher = await _dbContext.Vouchers.ToListAsync();
            var t = listVoucher.FirstOrDefault(x => x.Ma == obj.Ma);
            if (t != null)
            {
                return BadRequest("Thất bại. Mã đã tồn tại");
            }
            else
            {
                try
                {
                    await _dbContext.Vouchers.AddAsync(obj);
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
        public async Task<IActionResult> Update(Voucher obj)
        {
            try
            {
                var l = await _dbContext.Vouchers.FindAsync(obj.ID);
                l.Name = obj.Name;
                l.GiaTri = obj.GiaTri;
                l.SoLuong = obj.SoLuong;
                l.StartDay = obj.StartDay;
                l.EndDay = obj.EndDay;
                _dbContext.Vouchers.Update(l);
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
                var t = await _dbContext.Vouchers.FindAsync(id);
                _dbContext.Vouchers.Remove(t);
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
            var voucher = await _dbContext.Vouchers.FindAsync(id);
            return Ok(voucher);
        }
    }
}
