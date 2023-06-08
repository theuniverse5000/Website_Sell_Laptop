
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Color
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string Ma { get; set; }

        public string Name { get; set; }

        public ICollection<ProductDetail> ProductDetails { get; set; }

    }
}
