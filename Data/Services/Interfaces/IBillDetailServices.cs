using Data.Models;
using Data.Models.ViewModels;

namespace Data.Services.Interfaces
{
    public interface IBillDetailServices
    {
        Task<bool> CreateBillDetail(BillDetail obj);
        Task<bool> UpdateBillDetail(BillDetail obj);
        Task<bool> DeleteBillDetail(Guid id);
        Task<List<BillDetail>> GetAllBillDetails();
        Task<BillDetail> GetBillDetailById(Guid id);
        Task<List<BillView>> GetBillDetailJoinFull();

    }
}
