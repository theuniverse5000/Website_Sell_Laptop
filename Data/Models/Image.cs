namespace Data.Models
{
    public class Image
    {
        public Guid Id { get; set; }

        public string Ma { get; set; }

        public string LinkImage { get; set; }
        public Guid IdProductDetail { get; set; }

        public virtual ProductDetail ProductDetail { get; set; }

    }
}
