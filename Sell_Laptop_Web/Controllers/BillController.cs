using Data.Models;
using Data.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Sell_Laptop_Web.Controllers
{
    public class BillController : Controller
    {
        public async Task<IActionResult> Create(string maVoucher)
        {
            var httpClient = new HttpClient(); // tạo 1 http client để call api
            var reponseUser = await httpClient.GetAsync("https://localhost:44346/api/User");
            var reponseCartDetail = await httpClient.GetAsync("https://localhost:44346/api/CartDetail");
            string apiDataUser = await reponseUser.Content.ReadAsStringAsync();
            string apiDataCartDetail = await reponseCartDetail.Content.ReadAsStringAsync();
            var listUser = JsonConvert.DeserializeObject<List<User>>(apiDataUser);
            var thao = listUser.FirstOrDefault(x => x.Id == Guid.Parse("41008f74-9aa4-4e4f-97b1-7cd412be7e97"));
            var listCartDetail = JsonConvert.DeserializeObject<List<CartDetailView>>(apiDataCartDetail);
            var listItemInCart = listCartDetail.Where(x => x.UserId == Guid.Parse("41008f74-9aa4-4e4f-97b1-7cd412be7e97")).ToList();
            Bill bill = new Bill();
            bill.Id = Guid.NewGuid();
            bill.Ma = "Bill_" + DateTime.Now.ToString();
            bill.CreateDate = DateTime.Now;
            bill.SdtKhachHang = thao.PhoneNumber;
            bill.HoTenKhachHang = thao.FullName;
            bill.DiaChiKhachHang = thao.Address;
            bill.Status = 0;
            bill.UserId = Guid.Parse("41008f74-9aa4-4e4f-97b1-7cd412be7e97");
            var reponseVoucher = await httpClient.GetAsync("https://localhost:44346/api/Voucher");
            string apiDataVoucher = await reponseVoucher.Content.ReadAsStringAsync();
            var listVoucher = JsonConvert.DeserializeObject<List<Voucher>>(apiDataVoucher);
            var voucherX = listVoucher.FirstOrDefault(x => x.Ma == maVoucher);
            bill.VoucherId = voucherX != null ? voucherX.ID : null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/Bill");
                var postTask = client.PostAsJsonAsync<Bill>(client.BaseAddress, bill);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    foreach (var item in listItemInCart)
                    {
                        BillDetail billDetail = new BillDetail();
                        billDetail.Id = Guid.NewGuid();
                        billDetail.IdBill = bill.Id;
                        billDetail.IdProductDetails = item.IdProductDetails;
                        billDetail.Quantity = item.Quantity;
                        billDetail.Price = item.Price;
                        var postTask2 = client.PostAsJsonAsync<BillDetail>("https://localhost:44346/api/BillDetail", billDetail);
                        postTask2.Wait();
                        var result2 = postTask2.Result;
                        if (result2.IsSuccessStatusCode)
                        {
                            RedirectToAction("QuanLyBill", "Bill");
                        }
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> QuanLyBill()
        {
            var httpClient = new HttpClient(); // tạo 1 http client để call api
                                               //   var reponseCart = await httpClient.GetAsync("https://localhost:44346/api/Cart");
            var reponseBill = await httpClient.GetAsync("https://localhost:44346/api/Bill");
            //    string apiDataCart = await reponseCart.Content.ReadAsStringAsync();
            string apiDataBill = await reponseBill.Content.ReadAsStringAsync();
            //   var listCart = JsonConvert.DeserializeObject<List<Cart>>(apiDataCart);
            var listBill = JsonConvert.DeserializeObject<List<Bill>>(apiDataBill);
            ViewBag.listBill = listBill;
            return View(listBill);
        }
        public async Task<IActionResult> ShowBillItem(Guid id)
        {
            var httpClient = new HttpClient(); // tạo 1 http client để call api
            var reponseBillDetail = await httpClient.GetAsync("https://localhost:44346/api/BillDetail");
            string apiDataBillDetail = await reponseBillDetail.Content.ReadAsStringAsync();
            var listBillDetail = JsonConvert.DeserializeObject<List<BillView>>(apiDataBillDetail);
            var billDetailX = listBillDetail.Where(a => a.IdBill == id);
            return View(billDetailX);
        }


    }
}
