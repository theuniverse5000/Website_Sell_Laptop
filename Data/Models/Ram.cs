
namespace Data.Models
{
    public class Ram
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string ThongSo { get; set; }
        public int SoKheCam { get; set; }
        public string MoTa { get; set; }
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }

    }

}
