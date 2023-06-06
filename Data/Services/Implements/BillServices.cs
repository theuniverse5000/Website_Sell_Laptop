using Data.Models;
using Data.Models.ViewModels;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Implements
{
    public class BillServices : IBillServices
    {
        ApplicationDbContext _dbContext;
        IProductDetailServices _productDetailServices;
        public BillServices()
        {
            _dbContext = new ApplicationDbContext();
            _productDetailServices = new ProductDetailServices();
        }

        public async Task<bool> CreateBill(Bill obj)
        {
            try
            {
                await _dbContext.Bills.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteBill(Guid id)
        {
            try
            {
                var listBill = await _dbContext.Bills.ToListAsync();
                var bill = listBill.FirstOrDefault(t => t.Id == id);
                if (bill != null)
                {
                    //_dbContext.Bills.Attach(bill);
                    _dbContext.Bills.Remove(bill);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<BillView>> GetAllBillJoinFull()
        {
            List<BillView> listBill = new List<BillView>();
            listBill = (
                 from a in await _dbContext.Bills.ToListAsync()
                 join b in await _dbContext.BillDetails.ToListAsync() on a.Id equals b.IdBill
                 join c in await _dbContext.ProductDetails.ToListAsync() on b.IdProductDetails equals c.Id
                 join d in await _dbContext.Vouchers.ToListAsync() on a.VoucherId equals d.ID
                 select new BillView
                 {
                     IdBill = a.Id,
                     MaBill = a.Ma,
                     UserId = a.UserId,
                     CreateDate = a.CreateDate,
                     SdtKhachHang = a.SdtKhachHang,
                     HoTenKhachHang = a.HoTenKhachHang,
                     DiaChiKhachHang = a.DiaChiKhachHang,
                 }
                 ).ToList();

            return listBill;
        }

        public async Task<List<Bill>> GetAllBills()
        {
            return await _dbContext.Bills.ToListAsync();
        }

        public async Task<Bill> GetBillById(Guid id)
        {
            return await _dbContext.Bills.FindAsync(id);
        }

        public async Task<bool> UpdateBill(Bill obj)
        {
            try
            {
                var b = _dbContext.Bills.Find(obj.Id);
                b.HoTenKhachHang = obj.HoTenKhachHang;
                b.DiaChiKhachHang = obj.DiaChiKhachHang;
                b.SdtKhachHang = obj.SdtKhachHang;
                b.Status = obj.Status;
                _dbContext.Bills.Update(b);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateStatusBill(Guid id)
        {
            try
            {
                var b = await _dbContext.Bills.FindAsync(id);
                b.Status = 1;
                _dbContext.Bills.Update(b);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        //    public List<BillView> GetAllBillJoinFull()
        //    {
        //        List<BillView> bills = new List<BillView>();
        //        bills = (

        //                 from a in _dbContext.Bills.ToList()
        //                 join b in _dbContext.BillDetails.ToList() on a.Id equals b.IdBill
        //                 join c in _productDetailServices.GetAllProductDetailsPhunData() on b.IdProductDetails equals c.Id
        //                 join d in _dbContext.Vouchers.ToList() on a.VoucherId equals d.ID
        //                 select new BillView
        //                 {
        //                     IdBill = a.Id,
        //                     MaBill = a.Ma,
        //                     UserId = a.UserId,
        //                     CreateDate = a.CreateDate,
        //                     SdtKhachHang = a.SdtKhachHang,
        //                     HoTenKhachHang = a.HoTenKhachHang,
        //                     DiaChiKhachHang = a.DiaChiKhachHang,
        //                     Status = a.Status,
        //                     Quantity = b.Quantity,
        //                     Price = b.Price,
        //                     IdBillDetail = b.Id,
        //                     NameProduct = c.NameProduct,
        //                     NameCpu = c.NameCpu,
        //                     ThongSoRam = c.ThongSoRam,
        //                     ThongSoHardDrive = c.ThongSoHardDrive,
        //                     MaVoucher = d.Ma,
        //                     GiaTriVoucher = d.GiaTri
        //                 }
        //          ).ToList();
        //        return bills;
        //    }

        //    public Bill GetBillById(Guid id)
        //    {
        //        return _dbContext.Bills.Find(id);
        //    }

        //    public bool UpdateStatusBill(Guid Id)
        //    {
        //        try
        //        {
        //            var linh = _dbContext.Bills.Find(Id);
        //            linh.Status = 1;
        //            _dbContext.Bills.Update(linh);
        //            _dbContext.SaveChanges();
        //            return true;
        //        }
        //        catch (Exception)
        //        {

        //            return false;
        //        }
        //    }
    }
}
