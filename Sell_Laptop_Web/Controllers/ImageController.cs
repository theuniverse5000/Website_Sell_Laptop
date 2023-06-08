using Data.Models;
using Data.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Sell_Laptop_Web.Controllers
{
    public class ImageController : Controller
    {
        static List<ProductDetailView> listPro;
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            var reponsePro = await client.GetAsync("https://localhost:44346/api/ProductDetail");
            string apiDataPro = await reponsePro.Content.ReadAsStringAsync();
            listPro = JsonConvert.DeserializeObject<List<ProductDetailView>>(apiDataPro);
            ViewBag.listProductDetail = listPro;
            var reponse = await client.GetAsync("https://localhost:44346/api/Image");
            string apiData = await reponse.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<Image>>(apiData);
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            HttpClient client = new HttpClient();
            var reponse = await client.GetAsync("https://localhost:44346/api/ProductDetail");
            string apiData = await reponse.Content.ReadAsStringAsync();
            listPro = JsonConvert.DeserializeObject<List<ProductDetailView>>(apiData);
            ViewBag.listProductDetail = listPro;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Image obj, IFormFile imageFile, string maProductDetail)
        {
            HttpClient client = new HttpClient();
            Guid idProductDetail = listPro.FirstOrDefault(x => x.Ma == maProductDetail).Id;
            client.BaseAddress = new Uri("https://localhost:44346/api/Image");
            //  Truyền thêm 1 tham số vào action;
            // Truyền thêm 1 tham số imageFile kiểu IFormFile
            // Bước 1 : Kiểm tra đường dẫn tới ảnh được lấy từ form
            if (imageFile != null && imageFile.Length > 0)// Khác null , khác rỗng
            {
                // Bước 2
                // thực hiện việc trỏ tới mục wwwroot để sau thực viện việc copy
                var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "UploadImages", imageFile.FileName);
                // Path.Combine : Tổng hợp đường dẫn
                // Kết quả ttt/wwwroot/UploadImages/***.jpg
                var stream = new FileStream(path, FileMode.Create);
                // Thực hiện việc copy => tạo mới => Create
                imageFile.CopyTo(stream);// Coppy ảnh từ form vào thư mục wwwroot/UploadImages
                obj.LinkImage = imageFile.FileName;// Gán giá trị cho thuộc tính LinkImage
                obj.IdProductDetail = idProductDetail;

                var result = client.PostAsJsonAsync(client.BaseAddress, obj).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(obj);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {

            return View();
        }
        public async Task<IActionResult> Update(Image obj, IFormFile imageFile)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44346/api/Image");
            if (imageFile != null && imageFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "UploadImages", imageFile.FileName);
                var stream = new FileStream(path, FileMode.Create);
                imageFile.CopyTo(stream);
                obj.LinkImage = imageFile.FileName;


                var result = client.PutAsJsonAsync(client.BaseAddress, obj).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(obj);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"https://localhost:44346/api/Image/id?Id={id}");
            var result = client.DeleteAsync(client.BaseAddress).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}
