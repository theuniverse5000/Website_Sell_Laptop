namespace Sell_Laptop_API.Models
{
    public class Image
    {
        public Guid Id { get; set; }

        public string Ma { get; set; }

        public string LinkImage { get; set; }
        public Guid IdProduct { get; set; }

        public virtual Product Product { get; set; }

    }
}
