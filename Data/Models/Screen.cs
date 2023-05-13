namespace Data.Models
{
    public class Screen
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string KichCo { get; set; }
        public string TanSo { get; set; }
        public string ChatLieu { get; set; }

        public ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
