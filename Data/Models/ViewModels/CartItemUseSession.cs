using Data.Models;

namespace Data.Models.ViewModels
{
    public class CartItemUseSession
    {
        public Guid IdProductDetail { get; set; }

        public string Ma { get; set; }

        public decimal ImportPrice { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
        public int Status { get; set; }

        public string Description { get; set; }


        public Guid IdProduct { get; set; }
        public Guid IdColor { get; set; }
        public Guid IdRam { get; set; }
        public Guid IdCpu { get; set; }
        public Guid IdHardDrive { get; set; }

        public virtual Product Product { get; set; }
        public virtual Color Color { get; set; }
        public virtual Ram Ram { get; set; }
        public virtual Cpu Cpu { get; set; }
        public virtual HardDrive HardDrive { get; set; }
        public string ThongSoRam { get; set; }
        public string ThongSoHardDrive { get; set; }
        public string NameCpu { get; set; }
        public string NameColor { get; set; }
        public string NameProduct { get; set; }
        public string NameProduce { get; set; }
        public string LinkImage { get; set; }
        public int SoLuongTrongCart { get; set; }
        

    }
}
