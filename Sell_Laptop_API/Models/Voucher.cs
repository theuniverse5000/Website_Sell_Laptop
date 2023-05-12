using Sell_Laptop_API.Models;

namespace Sell_Laptop_API.Models
{
    public class Voucher
    {
        public Guid ID { get; set; }
        public string Ma { get; set; }
        public string Name { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public float GiaTri { get; set; }
        public int SoLuong { get; set; }
        public ICollection<Bill> Bills { get; set; }
    }
}
