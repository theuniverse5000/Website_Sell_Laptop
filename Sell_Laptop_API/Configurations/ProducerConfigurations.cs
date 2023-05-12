using Sell_Laptop_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sell_Laptop_API.Configurations
{
    public class ProducerConfigurations : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.ToTable("Producer");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasColumnName("Name").HasColumnType("nvarchar(50)").IsRequired();
        }
    }
}
