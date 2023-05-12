
namespace Sell_Laptop_API.Models
{
    public class CartDetail
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid IdProductDetails { get; set; }
        public int Quantity { get; set; }
        public virtual Cart Cart { get; set; }

        public virtual ProductDetail ProductDetail { get; set; }

    }
}
