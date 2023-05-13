namespace Data.Models
{
    public class CardVGA
    {
        public Guid Id { get; set; }

        public string Ma { get; set; }

        public string Ten { get; set; }
        public string ThongSo { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
