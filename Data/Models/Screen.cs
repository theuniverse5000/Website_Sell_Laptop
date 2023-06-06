using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Screen
    {
        [Required] // Bắt buộc phải có
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [Range(0, 20, ErrorMessage = "Phải trong khoàng")]
        // [EmailAddress(ErrorMessage ="Sai định dạng")]
        public string Ten { get; set; }
        public string KichCo { get; set; }
        public string TanSo { get; set; }
        public string ChatLieu { get; set; }

        public ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
