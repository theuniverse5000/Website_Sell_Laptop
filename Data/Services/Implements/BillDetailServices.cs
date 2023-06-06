using Data.Models;
using Data.Models.ViewModels;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Implements
{
    public class BillDetailServices : IBillDetailServices
    {
        ApplicationDbContext _dbContext;
        public BillDetailServices()
        {
            _dbContext = new ApplicationDbContext();
        }

        public async Task<bool> CreateBillDetail(BillDetail obj)
        {
            try
            {
                if (obj == null) return false;
                else
                {
                    await _dbContext.BillDetails.AddAsync(obj);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteBillDetail(Guid id)
        {
            try
            {
                var x = await _dbContext.BillDetails.FindAsync(id);
                if (x == null) return false;
                else
                {
                    _dbContext.BillDetails.Remove(x);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<List<BillDetail>> GetAllBillDetails()
        {
            return await _dbContext.BillDetails.ToListAsync();
        }

        public async Task<BillDetail> GetBillDetailById(Guid id)
        {
            return await _dbContext.BillDetails.FindAsync(id);
        }

        public async Task<List<BillView>> GetBillDetailJoinFull()
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
                     IdBillDetail = b.Id,
                     MaProductDetail = c.Ma,
                     Price = b.Price,
                     Quantity = b.Quantity,
                     MaVoucher = d.Ma,
                     GiaTriVoucher = d.GiaTri
                 }
                 ).ToList();
            return listBill;
        }

        public async Task<bool> UpdateBillDetail(BillDetail obj)
        {
            try
            {
                var x = await _dbContext.BillDetails.FindAsync(obj.Id);
                if (x == null) return false;
                else
                {
                    x.Quantity = obj.Quantity;
                    x.Price = obj.Price;
                    _dbContext.BillDetails.Update(x);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
