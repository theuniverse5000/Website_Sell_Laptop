using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ImageConfigurations : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Image");
            // builder.HasKey(x => new { x.IDHoaDon, x.IDChiTietLapTop });
            builder.HasKey(x => x.Id);
            builder.Property(a => a.Ma).HasColumnName("Ma").HasColumnType("varchar(30)").IsRequired();
            builder.Property(p => p.LinkImage).HasColumnName("HinhAnh").HasColumnType("nvarchar(max)").IsRequired();
            builder.HasOne(x => x.ProductDetail).WithMany(x => x.Imagess).HasForeignKey(x =>x.IdProductDetail);
        }
    }
}
