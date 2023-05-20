using Data.Models;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Sell_Laptop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuController : ControllerBase
    {
        private readonly ICpuServices _cpuServices;
        public CpuController(ICpuServices cpuServices)
        {
            _cpuServices = cpuServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCpus()
        {
            return Ok(await _cpuServices.GetAllCpus());
        }
        [HttpPost]
        public async Task<IActionResult> CreatCpu(Cpu obj)
        {
            if (await _cpuServices.CreateCpu(obj))
            {
                return Ok("Bạn đã thêm thành công");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCpu(Guid id)
        {
            if (await _cpuServices.DeleteCpu(id))
            {
                return Ok("Bạn đã xóa thành công");
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
