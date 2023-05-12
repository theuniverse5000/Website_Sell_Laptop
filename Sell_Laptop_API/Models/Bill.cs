
using Sell_Laptop_API.Models;

namespace Sell_Laptop_API.Models
{
    public class Bill
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public DateTime CreateDate { get; set; }
        public string SdtKhachHang { get; set; }
        public string HoTenKhachHang { get; set; }
        public string DiaChiKhachHang { get; set; } 
        public Guid UserId { get; set; }
        public Guid VoucherId { get; set; }
        public int Status { get; set; }
        public virtual User User { get; set; }   
        public virtual Voucher Voucher { get; set; }
        public ICollection<BillDetail> BillDetails { get; set; }

        //  ICollection có thể thay bằng List
    }
}
