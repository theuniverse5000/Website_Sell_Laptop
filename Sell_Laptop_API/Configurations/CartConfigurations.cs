using Sell_Laptop_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sell_Laptop_API.Configurations
{
    public class CartConfigurations : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");
            builder.HasKey(p => p.UserId);
            builder.Property(p => p.Description).
                HasColumnType("nvarchar(100)");
        }
    }
}
