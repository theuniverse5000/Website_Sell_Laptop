using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Sell_Laptop_Web.Controllers
{
    public class CardVGAController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/CardVGA");
            var reponse = await client.GetAsync(client.BaseAddress);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<CardVGA>>(apiData);
            return View(list);
        }
        public async Task<IActionResult> Create(CardVGA obj)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/CardVGA");
            var result = await client.PostAsJsonAsync(client.BaseAddress, obj);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "CardVGA");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            return View();
        }
        public async Task<IActionResult> Update(CardVGA obj)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/CardVGA");
            var result = await client.PutAsJsonAsync(client.BaseAddress, obj);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "CardVGA");
            }
            return View();
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"https://localhost:44346/api/CardVGA/id?Id={id}");
            var result = await client.DeleteAsync(client.BaseAddress);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "CardVGA");
            }
            return BadRequest();
        }
    }
}
