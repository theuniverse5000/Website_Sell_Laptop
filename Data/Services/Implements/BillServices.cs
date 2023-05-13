using Data.Models;
using Data.Models.ViewModels;
using Data.Services.Interfaces;

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
        public bool CreateBill(Bill thao)
        {
            try
            {
                _dbContext.Bills.Add(thao);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool DeleteBill(Guid id)
        {
            try
            {
                var thao = _dbContext.Bills.Find(id);
                _dbContext.Bills.Remove(thao);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<BillView> GetAllBillJoinFull()
        {
            List<BillView> bills = new List<BillView>();
            bills = (

                     from a in _dbContext.Bills.ToList()
                     join b in _dbContext.BillDetails.ToList() on a.Id equals b.IdBill
                     join c in _productDetailServices.GetAllProductDetailsPhunData() on b.IdProductDetails equals c.Id
                     join d in _dbContext.Vouchers.ToList() on a.VoucherId equals d.ID
                     select new BillView
                     {
                         IdBill = a.Id,
                         MaBill = a.Ma,
                         UserId = a.UserId,
                         CreateDate = a.CreateDate,
                         SdtKhachHang = a.SdtKhachHang,
                         HoTenKhachHang = a.HoTenKhachHang,
                         DiaChiKhachHang = a.DiaChiKhachHang,
                         Status = a.Status,
                         Quantity = b.Quantity,
                         Price = b.Price,
                         IdBillDetail = b.Id,
                         NameProduct = c.NameProduct,
                         NameCpu = c.NameCpu,
                         ThongSoRam = c.ThongSoRam,
                         ThongSoHardDrive = c.ThongSoHardDrive,
                         MaVoucher = d.Ma,
                         GiaTriVoucher = d.GiaTri
                     }
              ).ToList();
            return bills;
        }

        public List<Bill> GetAllBills()
        {
            return _dbContext.Bills.ToList();
        }

        public Bill GetBillById(Guid id)
        {
            return _dbContext.Bills.Find(id);
        }

        public bool UpdateBill(Bill thao)
        {
            try
            {
                var linh = _dbContext.Bills.Find(thao.Id);
                linh.HoTenKhachHang = thao.HoTenKhachHang;
                linh.DiaChiKhachHang = thao.DiaChiKhachHang;
                linh.SdtKhachHang = thao.SdtKhachHang;
                linh.Status = thao.Status;
                _dbContext.Bills.Update(linh);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateStatusBill(Guid Id)
        {
            try
            {
                var linh = _dbContext.Bills.Find(Id);
                linh.Status = 1;
                _dbContext.Bills.Update(linh);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
