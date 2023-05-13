using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sell_Laptop_API.Models;
using Sell_Laptop_API.Services.Interfaces;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamAPIController : ControllerBase
    {
      //  private readonly ApplicationDbContext _dbContext;
        //  ApplicationDbContext _dbContext;
        private readonly IRamServices _ramServices;
        public RamAPIController(IRamServices ramServices)
        {
            //_dbContext = new ApplicationDbContext();
            _ramServices = ramServices;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Ram>> GetRam()
        {
            if (_ramServices == null)
            {
                return NotFound();
            }
            return _ramServices.GetAllRams();
        }
        [HttpPost]
        public ActionResult CreateRam(Ram r)
        {
            Ram rams = new Ram();
            rams.Id = Guid.NewGuid();
            rams.Ma = r.Ma;
            rams.ThongSo = r.ThongSo;
            _ramServices.CreateRam(rams);
            return Ok("Thêm thành công");
        }
        //[HttpPut("id")]
        //public ActionResult UpdateRam(Ram rv)
        //{
        //    var r = _dbContext.Rams.Find(rv.Id);
        //    r.ThongSo = rv.ThongSo;
        //    r.Ma = rv.Ma;
        //    _dbContext.Rams.Update(r);
        //    _dbContext.SaveChanges();
        //    return Ok("Bạn đã cập nhật thành công");
        //}
        [HttpDelete]
        [Route("id")]
        public ActionResult DeleteRam(Guid Id)
        {
           // var x = _ramServices.GetAllRams().FirstOrDefault(a=>a.Id==Id);
            _ramServices.DeleteRam(Id);
            return Ok("Bạn đã xóa thành công");
        }
    }
}
