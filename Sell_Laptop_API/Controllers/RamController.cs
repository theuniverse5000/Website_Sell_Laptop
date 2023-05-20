﻿using Data.Models;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamController : ControllerBase
    {
        private readonly IRamServices _ramServices;
        public RamController(IRamServices ramServices)
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
            rams.SoKheCam = r.SoKheCam;
            rams.MoTa = r.MoTa;
            if (_ramServices.CreateRam(rams))
            {
                return Ok("Thêm thành công");
            }
            else return BadRequest("Thất bai");

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
            if (_ramServices.DeleteRam(Id))
                return Ok("Bạn đã xóa thành công");
            else return BadRequest("Thất bái !");
        }
    }
}
