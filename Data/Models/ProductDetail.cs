
namespace Data.Models
{
    public class ProductDetail
    {
        public Guid Id { get; set; }

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
        public Guid IdScreen { get; set; }
        public Guid IdCardVGA { get; set; }
        public virtual Product Product { get; set; }
        public virtual Color Color { get; set; }
        public virtual Ram Ram { get; set; }
        public virtual Cpu Cpu { get; set; }
        public virtual Screen Screen { get; set; }
        public virtual CardVGA CardVGA { get; set; }
        public virtual HardDrive HardDrive { get; set; }
        public ICollection<Image> Imagess { get; set; }
        public ICollection<BillDetail> BillDetails { get; set; }
        public ICollection<CartDetail> CartDetails { get; set; }


    }
}
