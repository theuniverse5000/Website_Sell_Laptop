using Data.Models;
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
