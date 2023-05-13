using Data.Models;
using Data.Models.ViewModels;

namespace Data.Services.Interfaces
{
    public interface IBillDetailServices
    {
        bool CreateBillDetail(BillDetail thao);
        bool UpdateBillDetail(BillDetail thao);
        bool DeleteBillDetail(Guid id);
        //bool IsBillDetailnameExist(string BillDetailname);
        List<BillDetail> GetAllBillDetails();
        BillDetail GetBillDetailById(Guid id);

        //List<BillDetail> GetBillDetailByName(string BillDetailname);
    }
}
