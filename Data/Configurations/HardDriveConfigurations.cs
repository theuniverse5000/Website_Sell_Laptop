using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class HardDriveConfigurations : IEntityTypeConfiguration<HardDrive>
    {
        public void Configure(EntityTypeBuilder<HardDrive> builder)
        {
            builder.ToTable("HardDrive");
            builder.HasKey(p => p.Id);
            builder.Property(a => a.Ma).IsRequired();
            builder.Property(a => a.ThongSo).HasColumnName("ThongSo").HasColumnType("varchar(70)").IsRequired();
            builder.Property(a => a.MoTa).HasColumnName("MoTa").HasColumnType("nvarchar(150)").IsRequired();

        }
    }
}
