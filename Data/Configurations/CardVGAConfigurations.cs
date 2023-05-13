using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class CardVGAConfigurations : IEntityTypeConfiguration<CardVGA>
    {
        public void Configure(EntityTypeBuilder<CardVGA> builder)
        {
            builder.ToTable("CardVGA");
            builder.HasKey(p => p.Id);
            builder.Property(a => a.Ma).IsRequired();
            builder.Property(a => a.ThongSo).HasColumnName("ThongSo").HasColumnType("varchar(70)").IsRequired();
            builder.Property(a => a.Ten).HasColumnName("Ten").HasColumnType("varchar(200)").IsRequired();
        }
    }
}
