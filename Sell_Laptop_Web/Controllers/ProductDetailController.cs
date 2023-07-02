using Data.Models;
using Data.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Sell_Laptop_Web.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly HttpClient _client;
        static List<Ram> listRam;
        static List<Cpu> listCpu;
        static List<HardDrive> listHardDrive;
        static List<Product> listProduct;
        static List<Screen> listScreen;
        static List<CardVGA> listCardVGA;
        static List<Color> listColor;
        public ProductDetailController()
        {
            _client = new HttpClient();
        }
        public async Task<IActionResult> Index()
        {
            var listProductDetail = await _client.GetFromJsonAsync<IList<ProductDetailView>>("https://localhost:44346/api/ProductDetail");
            ViewBag.listProductDetail = listProductDetail;
            return View(listProductDetail);
        }
        public async Task<ActionResult> Create()
        {
            //var listCpu = await _client.GetFromJsonAsync<List<Cpu>>("https://localhost:44346/api/Cpu");
            //ViewBag.listCpu = listCpu;
            //var listRam = await _client.GetFromJsonAsync<List<Ram>>("https://localhost:44346/api/Ram");
            //ViewBag.listRam = listRam;
            //var listHardDrive = await _client.GetFromJsonAsync<List<HardDrive>>("https://localhost:44346/api/HardDrive");
            //ViewBag.listHardDrive = listHardDrive;
            //var listScreen = await _client.GetFromJsonAsync<List<Screen>>("https://localhost:44346/api/Screen");
            //ViewBag.listScreen = listScreen;
            //var listProduct = await _client.GetFromJsonAsync<List<Product>>("https://localhost:44346/api/Product");
            //ViewBag.listProduct = listProduct;
            //var listColor = await _client.GetFromJsonAsync<List<Color>>("https://localhost:44346/api/Color");
            //ViewBag.listColor = listColor;
            //var listCardVGA = await _client.GetFromJsonAsync<List<CardVGA>>("https://localhost:44346/api/CardVGA");
            //ViewBag.listCardVGA = listCardVGA;
            var httpClient = new HttpClient(); // tạo 1 http client để call api
            var reponseCpu = await httpClient.GetAsync("https://localhost:44346/api/Cpu");
            var reponseRam = await httpClient.GetAsync("https://localhost:44346/api/Ram");
            var reponseHardDrive = await httpClient.GetAsync("https://localhost:44346/api/HardDrive");
            var reponseScreen = await httpClient.GetAsync("https://localhost:44346/api/Screen");
            var reponseProduct = await httpClient.GetAsync("https://localhost:44346/api/Product");
            var reponseColor = await httpClient.GetAsync("https://localhost:44346/api/Color");
            var reponseCardVGA = await httpClient.GetAsync("https://localhost:44346/api/CardVGA");

            string apiDataCpu = await reponseCpu.Content.ReadAsStringAsync();
            string apiDataRam = await reponseRam.Content.ReadAsStringAsync();
            string apiDataHardDrive = await reponseHardDrive.Content.ReadAsStringAsync();
            string apiDataScreen = await reponseScreen.Content.ReadAsStringAsync();
            string apiDataProduct = await reponseProduct.Content.ReadAsStringAsync();
            string apiDataColor = await reponseColor.Content.ReadAsStringAsync();
            string apiCardVGA = await reponseCardVGA.Content.ReadAsStringAsync();

            ViewBag.listCpu = JsonConvert.DeserializeObject<List<Cpu>>(apiDataCpu);
            listCpu = JsonConvert.DeserializeObject<List<Cpu>>(apiDataCpu);
            ViewBag.listRam = JsonConvert.DeserializeObject<List<Ram>>(apiDataRam);
            listRam = JsonConvert.DeserializeObject<List<Ram>>(apiDataRam);
            ViewBag.listHardDrive = JsonConvert.DeserializeObject<List<HardDrive>>(apiDataHardDrive);
            listHardDrive = JsonConvert.DeserializeObject<List<HardDrive>>(apiDataHardDrive);
            ViewBag.listScreen = JsonConvert.DeserializeObject<List<Screen>>(apiDataScreen);
            listScreen = JsonConvert.DeserializeObject<List<Screen>>(apiDataScreen);
            ViewBag.listProduct = JsonConvert.DeserializeObject<List<Product>>(apiDataProduct);
            listProduct = JsonConvert.DeserializeObject<List<Product>>(apiDataProduct);
            ViewBag.listColor = JsonConvert.DeserializeObject<List<Color>>(apiDataColor);
            listColor = JsonConvert.DeserializeObject<List<Color>>(apiDataColor);
            ViewBag.listCardVGA = JsonConvert.DeserializeObject<List<CardVGA>>(apiCardVGA);
            listCardVGA = JsonConvert.DeserializeObject<List<CardVGA>>(apiCardVGA);
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(ProductDetailView productDetailView)
        {
            ProductDetail productDetail = new ProductDetail();
            productDetail.Id = Guid.NewGuid();
            productDetail.Ma = productDetailView.Ma;
            productDetail.ImportPrice = productDetailView.ImportPrice;
            productDetail.Price = productDetailView.Price;
            productDetail.AvailableQuantity = productDetailView.AvailableQuantity;
            productDetail.Description = productDetailView.Description;
            productDetail.Status = productDetailView.Status; productDetail.IdRam = listRam.FirstOrDefault(x => x.Ma == productDetailView.MaRam).Id;
            productDetail.IdProduct = listProduct.FirstOrDefault(x => x.Name == productDetailView.NameProduct).Id;

            productDetail.IdCpu = listCpu.FirstOrDefault(x => x.Ma == productDetailView.MaCpu).Id;
            productDetail.IdHardDrive = listHardDrive.FirstOrDefault(x => x.Ma == productDetailView.MaHardDrive).Id;
            productDetail.IdScreen = listScreen.FirstOrDefault(x => x.Ma == productDetailView.MaManHinh).Id;
            productDetail.IdColor = listColor.FirstOrDefault(x => x.Ma == productDetailView.MaColor).Id;
            productDetail.IdCardVGA = listCardVGA.FirstOrDefault(x => x.Ma == productDetailView.MaCardVGA).Id;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/ProductDetail");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<ProductDetail>("ProductDetail", productDetail);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Thêm thất bại !!!");

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var productDetail = await _client.GetFromJsonAsync<ProductDetail>($"https://localhost:44346/api/ProductDetail/id?Id={id}");
            return View(productDetail);

        }
        public async Task<IActionResult> Update(ProductDetail productDetail)
        {
            var result = _client.PutAsJsonAsync<ProductDetail>("https://localhost:44346/api/ProductDetail", productDetail).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(productDetail);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            _client.BaseAddress = new Uri($"https://localhost:44346/api/ProductDetail/id?Id={id}");
            var result = _client.DeleteAsync(_client.BaseAddress).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
