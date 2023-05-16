using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ScreenConfigurations : IEntityTypeConfiguration<Screen>
    {
        public void Configure(EntityTypeBuilder<Screen> builder)
        {
            builder.ToTable("Screen");
            builder.HasKey(p => p.Id);
            builder.Property(a => a.Ma).IsRequired();
            builder.Property(a => a.Ten).HasColumnName("Ten").HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(a => a.KichCo).HasColumnName("KichCo").HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(a => a.TanSo).HasColumnName("TanSo").HasColumnType("nvarchar(20)").IsRequired();
            builder.Property(a => a.ChatLieu).HasColumnName("ChatLieu").HasColumnType("nvarchar(150)").IsRequired();
        }
    }
}
