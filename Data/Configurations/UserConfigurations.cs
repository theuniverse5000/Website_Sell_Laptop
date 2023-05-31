using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).HasColumnType("varchar(256)").IsRequired();
            builder.Property(x => x.Password).HasColumnType("varchar(256)").IsRequired();
            builder.Property(x => x.FullName).HasColumnType("nvarchar(256)");
            builder.Property(x => x.Address).HasColumnType("nvarchar(256)");
            builder.Property(x => x.PhoneNumber).HasColumnType("varchar(15)");
            builder.Property(x => x.Status).HasColumnType("int");
            builder.HasOne(p => p.Role).WithMany(p => p.Users).
                HasForeignKey(p => p.IdRole);
            builder.HasAlternateKey(p => p.Username); // Unique
        }
    }
}
