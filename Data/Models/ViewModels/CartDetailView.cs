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
        public string MaProductDetai { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
        public int Status { get; set; }
        public string MaRam { get; set; }
        public string ThongSoRam { get; set; }
        public int SoKheCamRam { get; set; }
        public string MoTaRam { get; set; }
        public string ThongSoHardDrive { get; set; }
        public string MoTaHardDrive { get; set; }
        public string MaCpu { get; set; }
        public string ThongSoCpu { get; set; }
        public string NameCpu { get; set; }
        public string NameColor { get; set; }
        public string NameProduct { get; set; }
        public string MaHardDrive { get; set; }
        public string MaColor { get; set; }
        public string NameManufacturer { get; set; }
        public string MaManHinh { get; set; }
        public string TenManHinh { get; set; }
        public string KichCoManHinh { get; set; }
        public string TanSoManHinh { get; set; }
        public string ChatLieuManHinh { get; set; }
        public string MaCardVGA { get; set; }
        public string TenCardVGA { get; set; }
        public string ThongSoCardVGA { get; set; }

        public string LinkImage { get; set; }
    }
}
