using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Sell_Laptop_Web.Controllers
{
    public class CpuController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string apiUrl = "https://localhost:44346/api/Cpu";// lấy url
            // sau khi có url lấy dữ liệu trả về từ nó
            var httpClient = new HttpClient(); // tạo 1 http client để call api
            var reponse = await httpClient.GetAsync(apiUrl);// lấy kết quả từ url
            string apiData = await reponse.Content.ReadAsStringAsync();// Đọc ra string json
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
            string apiUrl = "https://localhost:44346/api/Cpu";// lấy url
            // sau khi có url lấy dữ liệu trả về từ nó
            var httpClient = new HttpClient(); // tạo 1 http client để call api
            var reponse = await httpClient.PostAsJsonAsync<Cpu>(apiUrl, obj);// lấy kết quả từ url
            string apiData = await reponse.Content.ReadAsStringAsync();// Đọc ra string json

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(Guid id)
        {

            var httpClient = new HttpClient();
            var reponse = await httpClient.DeleteAsync($"https://localhost:44346/api/Cpu/id?id={id}");
            var apiData = await reponse.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }
    }
}
