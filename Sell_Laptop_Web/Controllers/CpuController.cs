using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Sell_Laptop_Web.Controllers
{
    public class CpuController : Controller
    {
        public async Task<IActionResult> Index()
        {

            string apiUrl = "https://localhost:44346/api/Cpu";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(apiUrl);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<Cpu>>(apiData);
            return View(list);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Cpu obj)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/Cpu");
            var result = client.PostAsJsonAsync<Cpu>(client.BaseAddress, obj).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Thêm thất bại !!!");
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Cpu x)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/Cpu");
            var result = client.PutAsJsonAsync(client.BaseAddress, x).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Thêm thất bại !!!");

            return View();
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:44346/api/Cpu/id?Id={id}");

                //HTTP DELETE
                var result = client.DeleteAsync(client.BaseAddress).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Thất bại !!!");
            return BadRequest();
        }
    }
}
