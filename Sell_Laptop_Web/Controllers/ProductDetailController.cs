﻿using Data.Models;
using Data.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sell_Laptop_Web.Services;

namespace Sell_Laptop_Web.Controllers
{
    public class ProductDetailController : Controller
    {
        CallAPIServices callAPI = new CallAPIServices();
        static List<Ram> listRam;
        static List<Cpu> listCpu;
        static List<HardDrive> listHardDrive;
        static List<Product> listProduct;
        static List<Screen> listScreen;
        static List<CardVGA> listCardVGA;
        static List<Color> listColor;
        public ProductDetailController()
        {

        }
        public Task<IActionResult> Index()
        {
            IEnumerable<ProductDetailView> productDetails = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/");
                //HTTP GET
                var responseTask = client.GetAsync("ProductDetail");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ProductDetailView>>();
                    readTask.Wait();

                    productDetails = readTask.Result;
                    ViewBag.listProductDetail = productDetails;
                }
                else //web api sent error response 
                {
                    //log response status here..
                    productDetails = Enumerable.Empty<ProductDetailView>();

                    ModelState.AddModelError(string.Empty, "Có lỗi xảy ra");
                }
                return Task.FromResult<IActionResult>(View(productDetails));
            }

            //  return View(await callAPI.GetAll<ProductDetailView>("https://localhost:44346/api/ProductDetail"));
        }
        public async Task<ActionResult> Create()
        {
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
            productDetail.Status = productDetailView.Status;
            productDetail.IdProduct = listProduct.FirstOrDefault(x => x.Name == productDetailView.NameProduct).Id;
            productDetail.IdRam = listRam.FirstOrDefault(x => x.Ma == productDetailView.MaRam).Id;
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
        public Task<IActionResult> Update(Guid id)
        {
            ProductDetail productDetail = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:44346/api/ProductDetail/id?Id={id}");
                //HTTP GET
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ProductDetail>();
                    readTask.Wait();

                    productDetail = readTask.Result;
                }
            }
            return Task.FromResult<IActionResult>(View(productDetail));
            //   return View();
        }
        public Task<IActionResult> Update(ProductDetail productDetail)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/ProductDetail");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<ProductDetail>(client.BaseAddress, productDetail);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return Task.FromResult<IActionResult>(RedirectToAction("Index"));
                }
            }
            return Task.FromResult<IActionResult>(View(productDetail));
        }

        public Task<IActionResult> Delete(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:44346/api/ProductDetail/id?Id={id}");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync(client.BaseAddress);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return Task.FromResult<IActionResult>(RedirectToAction("Index"));
                }
            }
            return Task.FromResult<IActionResult>(RedirectToAction("Index"));
        }

    }
}
