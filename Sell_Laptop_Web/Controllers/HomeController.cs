using Data.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Sell_Laptop_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _client;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _client = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            var listProductDetail = await _client.GetFromJsonAsync<List<ProductDetailView>>("https://localhost:44346/api/ProductDetail");
            ViewBag.listProductDetailIndex = listProductDetail;
            return View(listProductDetail);
        }
        public async Task<IActionResult> ShowChiTietSanPham(Guid id)
        {
            var productDetail = await _client.GetFromJsonAsync<ProductDetailView>($"https://localhost:44346/api/ProductDetail/id?id={id}");
            return View(productDetail);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}