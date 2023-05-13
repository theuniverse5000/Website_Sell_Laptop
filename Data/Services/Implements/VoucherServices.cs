using Data.Models;
using Data.Services.Interfaces;

namespace Data.Services.Implements
{
    public class VoucherServices : IVoucherServices
    {
        ApplicationDbContext _dbContext;
        public VoucherServices()
        {
            _dbContext = new ApplicationDbContext();
        }
        public List<Voucher> GetVouchers()
        {
            return _dbContext.Vouchers.ToList();
        }
    }
}
