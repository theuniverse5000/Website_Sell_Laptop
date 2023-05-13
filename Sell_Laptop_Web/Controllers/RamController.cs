using Microsoft.AspNetCore.Mvc;
using Sell_Laptop_API.Models;

namespace Sell_Laptop_Web.Controllers
{
    public class RamController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Ram> rams = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/");
                //HTTP GET
                var responseTask = client.GetAsync("RamAPI");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Ram>>();
                    readTask.Wait();

                    rams = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    rams = Enumerable.Empty<Ram>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            ViewBag.ListRam = rams;
            return View(rams);
        }
        public IActionResult CreateRam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateRam(Ram r)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/RamAPI");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Ram>("RamAPI", r);
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
      //  [Route("id")]
        public ActionResult DeleteRam(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:44346/api/RamAPI/id?Id={id}");

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
