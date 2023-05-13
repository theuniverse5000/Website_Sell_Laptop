
namespace Data.Models
{
    public class Product
    {
        public Guid Id { get; set; }


        public string Name { get; set; }

        public Guid IDManufacturer { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }


        public ICollection<ProductDetail> ProductDetails { get; set; }


       

    }
}
