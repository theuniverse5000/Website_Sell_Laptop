

using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Cpu
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string ThongSo { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }

    }
}
