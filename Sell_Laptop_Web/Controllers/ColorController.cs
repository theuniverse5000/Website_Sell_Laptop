using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Sell_Laptop_Web.Controllers
{
    public class ColorController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            var reponseColor = await client.GetAsync("https://localhost:44346/api/Color");
            string apiDataColor = await reponseColor.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<Color>>(apiDataColor);
            return View(list);
        }
        public async Task<IActionResult> Create(Color obj)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/Color");
            var result = client.PostAsJsonAsync(client.BaseAddress, obj).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Color");
            }
            return View(obj);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            return View();
        }
        public async Task<IActionResult> Update(Color obj)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/Color");
            var result = client.PutAsJsonAsync(client.BaseAddress, obj).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Color");
            }
            return View(obj);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"https://localhost:44346/api/Color/id?Id={id}");
            var result = client.DeleteAsync(client.BaseAddress).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Color");
            }
            return BadRequest();
        }
    }
}
