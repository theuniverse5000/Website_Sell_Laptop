using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Sell_Laptop_Web.Controllers
{
    public class HardDriveController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            var reponse = await client.GetAsync("https://localhost:44346/api/HardDrive");
            string apiData = await reponse.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<HardDrive>>(apiData);
            return View(list);
        }
        public async Task<IActionResult> Create(HardDrive obj)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/HardDrive");
            var result = client.PostAsJsonAsync(client.BaseAddress, obj).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {

            return View();
        }
        public async Task<IActionResult> Update(HardDrive obj)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/HardDrive");
            var result = client.PutAsJsonAsync(client.BaseAddress, obj).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"https://localhost:44346/api/HardDrive/id?Id={id}");
            var result = client.DeleteAsync(client.BaseAddress).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}
