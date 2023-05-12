using Sell_Laptop_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sell_Laptop_API.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).HasColumnType("varchar(256)");
            builder.Property(x => x.Password).HasColumnType("varchar(256)");
            builder.Property(x => x.Status).HasColumnType("int");
            builder.HasOne(p => p.Role).WithMany(p => p.Users).
                HasForeignKey(p => p.IdRole);
            builder.HasAlternateKey(p => p.Username); // Unique
        }
    }
}
