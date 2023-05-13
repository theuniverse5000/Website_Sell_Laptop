
namespace Data.Models
{
    public class BillDetail
    {

        public Guid Id { get; set; }
        public Guid IdProductDetails { get; set; }
        public Guid IdBill { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }// ảo k có thật

    }
}
