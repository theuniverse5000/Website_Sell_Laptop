using Sell_Laptop_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sell_Laptop_API.Configurations
{
    public class ColorConfigurations : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Color");
            builder.HasKey(p => p.Id);
            builder.Property(a => a.Ma).IsRequired();
            builder.Property(a => a.Name).HasColumnName("Name").HasColumnType("varchar(70)").IsRequired();
        }
    }
}
