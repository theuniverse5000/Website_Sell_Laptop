using Sell_Laptop_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sell_Laptop_API.Configurations
{
    public class RoleConfigurations : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.RoleName).HasColumnType("varchar(100)");
            builder.Property(p => p.Description).HasColumnType("nvarchar(1000)");
            builder.Property(p => p.Status).HasColumnType("int");
        }
    }
}
