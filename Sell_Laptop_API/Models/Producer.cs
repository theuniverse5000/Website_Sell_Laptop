

namespace Sell_Laptop_API.Models
{
    public class Producer
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
