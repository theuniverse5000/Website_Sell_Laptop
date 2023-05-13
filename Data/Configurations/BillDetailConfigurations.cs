using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class BillDetailConfigurations : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.ToTable("BillDetail");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Quantity).IsRequired().
                HasColumnType("int");
            // Set khóa ngoại
            builder.HasOne(p => p.Bill).WithMany(p => p.BillDetails).
                HasForeignKey(p => p.IdBill).HasConstraintName("FK_Bill");
            builder.HasOne(a => a.ProductDetail).WithMany(a => a.BillDetails).
                HasForeignKey(p => p.IdProductDetails).HasConstraintName("FK_ProductDetails");
        }
    }
}
