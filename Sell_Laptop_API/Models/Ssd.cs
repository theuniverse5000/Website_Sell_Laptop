

namespace Sell_Laptop_API.Models
{
    public class Ssd
    {
        public Guid Id { get; set; }

        public string Ma { get; set; }


        public string ThongSo { get; set; }


        public ICollection<ProductDetail> ProductDetails { get; set; }

    }
}
