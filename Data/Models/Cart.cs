
namespace Data.Models
{
    public class Cart
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
        public virtual User User { get; set; }

    }
}
