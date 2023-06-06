using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardVGAController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public CardVGAController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCardVGAs()
        {
            return Ok(await _dbContext.CardVGAs.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> CreateCardVGA(CardVGA obj)
        {
            var listCardVGA = await _dbContext.CardVGAs.ToListAsync();
            var t = listCardVGA.FirstOrDefault(x => x.Ma == obj.Ma);
            if (t != null)
            {
                return BadRequest("Thất bại. Mã đã tồn tại");
            }
            else
            {
                try
                {
                    obj.Id = Guid.NewGuid();
                    await _dbContext.CardVGAs.AddAsync(obj);
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
        public async Task<IActionResult> UpdateCardVGA(CardVGA obj)
        {
            try
            {
                var l = await _dbContext.CardVGAs.FindAsync(obj.Id);
                l.Ten = obj.Ten;
                l.ThongSo = obj.ThongSo;
                _dbContext.CardVGAs.Update(l);
                await _dbContext.SaveChangesAsync();
                return Ok("Thành công");
            }
            catch (Exception)
            {
                return BadRequest("Thất bại");
            }
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCardVGA(Guid id)
        {
            try
            {
                var t = await _dbContext.CardVGAs.FindAsync(id);
                _dbContext.CardVGAs.Remove(t);
                await _dbContext.SaveChangesAsync();
                return Ok("Bạn đã xóa thành công");
            }
            catch (Exception)
            {
                return BadRequest("Thất bại");
            }
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetCardVGAById(Guid id)
        {
            var cardVGA = await _dbContext.CardVGAs.FindAsync(id);
            return Ok(cardVGA);
        }
    }
}
