using Data.Models;
using Data.Models.ViewModels;

namespace Data.Services.Interfaces
{
    public interface IBillServices
    {
        bool CreateBill(Bill thao);
        bool UpdateBill(Bill thao);
        bool DeleteBill(Guid id);
        List<Bill> GetAllBills();
        Bill GetBillById(Guid id);
        List<BillView> GetAllBillJoinFull();
        bool UpdateStatusBill(Guid Id);
        //List<Bill> GetBillByName(string Billname);
    }
}
