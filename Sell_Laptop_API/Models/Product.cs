
namespace Sell_Laptop_API.Models
{
    public class Product
    {
        public Guid Id { get; set; }


        public string Name { get; set; }

        public Guid IdProducer { get; set; }

        public virtual Producer Producer { get; set; }


        public ICollection<ProductDetail> ProductDetails { get; set; }


        public ICollection<Image> Imagess { get; set; }

    }
}
