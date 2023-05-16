using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class CpuConfigurations : IEntityTypeConfiguration<Cpu>
    {
        public void Configure(EntityTypeBuilder<Cpu> builder)
        {
            builder.ToTable("CPU");
            builder.HasKey(p => p.Id);
            builder.Property(a => a.Ma).IsRequired();
            builder.Property(a => a.Name).HasColumnName("Name").HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(a => a.ThongSo).HasColumnName("ThongSo").HasColumnType("nvarchar(70)").IsRequired();
        }
    }
}
