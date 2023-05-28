using Data.Models;
using Data.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Sell_Laptop_Web.Services;

namespace Sell_Laptop_Web.Controllers
{
    public class CartController : Controller
    {
        CallAPIServices callAPI = new CallAPIServices();
        public async Task<IActionResult> Index()
        {

            Guid getUserId = Guid.Parse("41008f74-9aa4-4e4f-97b1-7cd412be7e97");
            //   ViewBag.GetCartForUser = _cartDetailServices.GetCartDetailJoinProductDetail().Where(a => a.UserId == getUserId);
            var listCartDetail = await callAPI.GetAll<CartDetailView>("https://localhost:44346/api/CartDetail");
            var itemInCart = listCartDetail.Where(x => x.UserId == getUserId).ToList();
            ViewBag.itemsInCart = itemInCart;
            return View(itemInCart);
          //  return View();
        }
        public async Task<IActionResult> AddCart(Guid id)
        {

            var listCart = await callAPI.GetAll<Cart>("https://localhost:44346/api/Cart");
            var cartNgan = listCart.FirstOrDefault(x => x.UserId == Guid.Parse("41008f74-9aa4-4e4f-97b1-7cd412be7e97"));
            if (cartNgan == null)
            {
                using (var client = new HttpClient())
                {
                    Cart t = new Cart();
                    t.UserId = Guid.Parse("41008f74-9aa4-4e4f-97b1-7cd412be7e97");
                    t.Description = "Chất lượng bình thường";

                    client.BaseAddress = new Uri("https://localhost:44346/api/Cart");
                    var postTask = client.PostAsJsonAsync<Cart>("Cart", t);
                    postTask.Wait();
                }
            }
            using (var client = new HttpClient())
            {
                CartDetail x = new CartDetail();
                x.Id = new Guid();
                x.IdProductDetails = id;
                x.UserId = Guid.Parse("41008f74-9aa4-4e4f-97b1-7cd412be7e97");
                x.Quantity = 1;
                client.BaseAddress = new Uri("https://localhost:44346/api/CartDetail");
                var postTask = client.PostAsJsonAsync<CartDetail>("CartDetail", x);
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
        public async Task<IActionResult> CongOneQuantity(Guid id)
        {
            //  Guid getUserId = Guid.Parse("41008f74-9aa4-4e4f-97b1-7cd412be7e97");
            var listCartDetail = await callAPI.GetAll<CartDetail>($"https://localhost:44346/api/CartDetail/GetCartDetailNoJoin");
            //   var itemInCart = listCartDetail.Where(x => x.UserId == getUserId).ToList();
            var x = listCartDetail.FirstOrDefault(x => x.Id == id);
            x.Quantity += 1;
            using (var client = new HttpClient())
            {
                //
                client.BaseAddress = new Uri("https://localhost:44346/api/CartDetail/UpdateQuantity");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<CartDetail>(client.BaseAddress, x);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    TempData["ThongBaoHanhDong"] = "Số lượng sản phẩm vừa tăng";
                    return RedirectToAction("Index", "Cart");
                }
            }
            return RedirectToAction("Index", "Cart");
        }
        public async Task<IActionResult> TruOneQuantity(Guid id)
        {
            //  Guid getUserId = Guid.Parse("41008f74-9aa4-4e4f-97b1-7cd412be7e97");
            var listCartDetail = await callAPI.GetAll<CartDetail>($"https://localhost:44346/api/CartDetail/GetCartDetailNoJoin");
            //   var itemInCart = listCartDetail.Where(x => x.UserId == getUserId).ToList();
            var x = listCartDetail.FirstOrDefault(x => x.Id == id);
            if (x.Quantity <= 1)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri($"https://localhost:44346/api/CartDetail/id?Id={id}");

                    //HTTP DELETE
                    var deleteTask = client.DeleteAsync(client.BaseAddress);
                    deleteTask.Wait();

                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["ThongBaoHanhDong"] = "Bạn vừa xóa sản phẩm khỏi giỏ hàng";
                        return RedirectToAction("Index", "Cart");
                    }
                }
            }
            else
            {
                x.Quantity -= 1;
                using (var client = new HttpClient())
                {
                    //
                    client.BaseAddress = new Uri("https://localhost:44346/api/CartDetail/UpdateQuantity");

                    //HTTP POST
                    var putTask = client.PutAsJsonAsync<CartDetail>(client.BaseAddress, x);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        TempData["ThongBaoHanhDong"] = "Số lượng sản phẩm vừa giảm";
                        return RedirectToAction("Index", "Cart");
                    }
                }
            }
            return RedirectToAction("Index", "Cart");
        }
        public async Task<IActionResult> DeleteItemInCart(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:44346/api/CartDetail/id?Id={id}");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync(client.BaseAddress);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["ThongBaoHanhDong"] = "Bạn vừa xóa sản phẩm khỏi giỏ hàng";
                    return RedirectToAction("Index", "Cart");
                }
            }
            return RedirectToAction("Index", "Cart");
        }
    }
}
