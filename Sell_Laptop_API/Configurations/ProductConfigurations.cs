using Sell_Laptop_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sell_Laptop_API.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasColumnType("nvarchar(100)");
            builder.HasOne(p => p.Producer).WithMany(p => p.Products).
               HasForeignKey(p => p.IdProducer).HasConstraintName("FK_Producer");
        }
    }
}
