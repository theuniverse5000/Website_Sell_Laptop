using Data.Models;
using Data.Models.ViewModels;

namespace Data.Services.Interfaces
{
    public interface IBillServices
    {
        Task<bool> CreateBill(Bill obj);
        Task<bool> UpdateBill(Bill obj);
        Task<bool> DeleteBill(Guid id);
        Task<List<Bill>> GetAllBills();
        Task<Bill> GetBillById(Guid id);
        Task<List<BillView>> GetAllBillJoinFull();
        Task<bool> UpdateStatusBill(Guid id);
    }
}
