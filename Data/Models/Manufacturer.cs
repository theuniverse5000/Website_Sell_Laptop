

namespace Data.Models
{
    public class Manufacturer
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
