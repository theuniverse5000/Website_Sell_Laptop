using Data.IRepositories;
using Data.Models;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenController : ControllerBase
    {
        IAllRepositories<Screen> irepos;// Tạo db con text
        ApplicationDbContext context = new ApplicationDbContext();
        public ScreenController()
        {
            // Tạo 1 AllRepo để gán cho IALlrepo (Dependency Injection)
            AllRepositories<Screen> repos =
                new AllRepositories<Screen>(context, context.Screens);
            irepos = repos;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await irepos.GetAllItem());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Screen screen)
        {
            var listScreen = await irepos.GetAllItem();
            var checkMa = listScreen.FirstOrDefault(x => x.Ma == screen.Ma);
            if (checkMa != null)
            {
                return BadRequest("Mã đã tồn tại. Hãy nhập mã khác");
            }
            if (await irepos.CreateItem(screen))
            {
                return Ok("Thành công");
            }
            else
            {
                return BadRequest("Thất bại");
            }
        }
        [HttpPut("id")]
        public async Task<IActionResult> Update(Screen screen)
        {
            var listScreen = await irepos.GetAllItem();
            var t = listScreen.FirstOrDefault(x => x.Id == screen.Id);
            t.Ten = screen.Ten;
            t.KichCo = screen.KichCo;
            t.TanSo = screen.TanSo;
            t.ChatLieu = screen.ChatLieu;
            if (await irepos.UpdateItem(t))
            {
                return Ok("Thành công");
            }
            else
            {
                return BadRequest("Thất bại");
            }
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var listScreen = await irepos.GetAllItem();
            var t = listScreen.FirstOrDefault(x => x.Id == id);
            if (await irepos.DeleteItem(t))
            {
                return Ok("Thành công");
            }
            else
            {
                return BadRequest("Thất bại");
            }
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var listScreen = await irepos.GetAllItem();
            var t = listScreen.FirstOrDefault(x => x.Id == id);
            return Ok(t);
        }
    }
}
