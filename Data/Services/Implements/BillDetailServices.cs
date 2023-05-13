using Data.Models;
using Data.Services.Interfaces;

namespace Data.Services.Implements
{
    public class BillDetailServices : IBillDetailServices
    {
        ApplicationDbContext _dbContext;
        IProductDetailServices _productDetailServices;
        public BillDetailServices()
        {
            _dbContext = new ApplicationDbContext();
            _productDetailServices = new ProductDetailServices();
        }
        public bool CreateBillDetail(BillDetail thao)
        {
            try
            {
                _dbContext.BillDetails.Add(thao);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeleteBillDetail(Guid id)
        {
            try
            {
                var linh = _dbContext.BillDetails.Find(id);
                _dbContext.BillDetails.Remove(linh);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<BillDetail> GetAllBillDetails()
        {
            return _dbContext.BillDetails.ToList();
        }

        public BillDetail GetBillDetailById(Guid id)
        {
            return _dbContext.BillDetails.Find(id);
        }

        //public List<BillDetail> GetBillDetailByName(string BillDetailname)
        //{
        //    return _dbContext.BillDetails.Where(a=>a.)
        //}

        //public bool IsBillDetailnameExist(string BillDetailname)
        //{
        //    throw new NotImplementedException();
        //}

        public bool UpdateBillDetail(BillDetail thao)
        {
            try
            {
                var linh = _dbContext.BillDetails.Find(thao.Id);
                linh.Quantity = thao.Quantity;
                linh.Price = thao.Price;
                _dbContext.BillDetails.Update(linh);
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
