namespace Data.Models.ViewModels
{
    public class BillView
    {
        public Guid IdBill { get; set; }
        public string MaBill { get; set; }
        public DateTime CreateDate { get; set; }
        public string SdtKhachHang { get; set; }
        public string HoTenKhachHang { get; set; }
        public string DiaChiKhachHang { get; set; }
        public Guid UserId { get; set; }
        public Guid VoucherId { get; set; }
        public int Status { get; set; }
        public Guid IdBillDetail { get; set; }
        public Guid IdProductDetails { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ThongSoRam { get; set; }
        public string ThongSoHardDrive { get; set; }
        public string NameCpu { get; set; }
        public string NameColor { get; set; }
        public string NameProduct { get; set; }
        public string MaRam { get; set; }
        public string MaHardDrive { get; set; }
        public string MaCpu { get; set; }
        public string MaColor { get; set; }
        public string MaProduct { get; set; }
        public string NameProduce { get; set; }
        public string LinkImage { get; set; }
        public string MaVoucher { get; set; }
        public string NameVoucher { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public float GiaTriVoucher { get; set; }
        public int SoLuongVoucher { get; set; }

    }
}
