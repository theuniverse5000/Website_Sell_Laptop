using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Sell_Laptop_Web.Controllers
{
    public class ProductDetailController : Controller
    {
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductDetail> productDetails = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/");
                //HTTP GET
                var responseTask = client.GetAsync("ProductDetail");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ProductDetail>>();
                    readTask.Wait();

                    productDetails = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    productDetails = Enumerable.Empty<ProductDetail>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(productDetails);
        }
        public async Task<ActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(ProductDetail productDetail)
        {
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

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
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
            return View(productDetail);
            //   return View();
        }
        // [HttpPut]
        public async Task<IActionResult> Update(ProductDetail productDetail)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/ProductDetail");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<ProductDetail>("ProductDetail", productDetail);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(productDetail);
        }

        public async Task<IActionResult> Delete(Guid id)
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

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

    }
}
