
namespace Sell_Laptop_API.Models
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
        public Guid IdSsd { get; set; }

        public virtual Product Product { get; set; }


        public virtual Color Color { get; set; }


        public virtual Ram Ram { get; set; }


        public virtual Cpu Cpu { get; set; }


        public virtual Ssd Ssd { get; set; }



        public ICollection<BillDetail> BillDetails { get; set; }


        public ICollection<CartDetail> CartDetails { get; set; }


    }
}
