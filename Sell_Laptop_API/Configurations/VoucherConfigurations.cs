
using Sell_Laptop_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sell_Laptop_API.Configurations
{
    internal class VoucherConfigurations : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.ToTable("Voucher");// Đặt tên bảng
            builder.HasKey(x => x.ID); // Set khóa chính
            // builder.Property(p => p.ID).UseIdentityColumn(1, 1);
            builder.Property(a => a.Name).HasColumnName("Name").HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(a => a.Ma).HasColumnName("Ma").HasColumnType("varchar(30)").IsRequired();
            builder.Property(a => a.StartDay).HasColumnName("StarDay").HasColumnType("datetime").IsRequired();
            builder.Property(a => a.EndDay).HasColumnName("EndDay").HasColumnType("datetime").IsRequired();
            builder.Property(a => a.GiaTri).HasColumnName("GiaTri").HasColumnType("money").IsRequired();
            builder.Property(a => a.SoLuong).HasColumnName("SoLuong").HasColumnType("int").IsRequired();

        }
    }
}
