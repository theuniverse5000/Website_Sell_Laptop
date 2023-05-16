﻿

namespace Data.Models
{
    public class HardDrive
    {
        public Guid Id { get; set; }

        public string Ma { get; set; }
        public string ThongSo { get; set; }
        public string MoTa { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }

    }
}
