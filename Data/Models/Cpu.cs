

namespace Data.Models
{
    public class Cpu
    {
        public Guid Id { get; set; }

        public string Ma { get; set; }


        public string Name { get; set; }


        public ICollection<ProductDetail> ProductDetails { get; set; }

    }
}
