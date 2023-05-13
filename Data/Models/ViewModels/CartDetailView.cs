using Data.Models;

namespace Data.Models.ViewModels
{
    public class CartDetailView
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid IdProductDetails { get; set; }
        public int Quantity { get; set; }
        public virtual Cart Cart { get; set; }

        public virtual ProductDetail ProductDetail { get; set; }
        public string DescriptionCart { get; set; }
        public string MaProductDetail { get; set; }
        public string NameProduct { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
        public int Status { get; set; }

        public string Description { get; set; }
        public string LinkImage { get; set; }
        public string ThongSoRam { get; set; }
        public string ThongSoHardDrive { get; set; }
        public string NameCpu { get; set; }
    }
}
