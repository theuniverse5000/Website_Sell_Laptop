using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class BillConfigurations : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bill"); // Đặt tên bảng
            builder.HasKey(p => new { p.Id });// Thiết lập khóa chính
                                              // Thiết lập cho các thuộc tính
            builder.Property(p => p.Ma).HasColumnName("Ma").HasColumnType("nvarchar(100)");
            builder.Property(p => p.HoTenKhachHang).HasColumnName("HoTenKhachHang").HasColumnType("nvarchar(100)");
            builder.Property(p => p.DiaChiKhachHang).HasColumnName("DiaChiKhachHang").HasColumnType("nvarchar(100)");
            builder.Property(p => p.SdtKhachHang).HasColumnName("SoDienThoaiKhachHang").HasColumnType("nvarchar(100)");
            builder.Property(p => p.Status).HasColumnType("int").
                IsRequired(); // int not null
            builder.HasOne(p => p.Voucher).WithMany(p => p.Bills).HasForeignKey(p => p.VoucherId);
            builder.HasOne(p => p.User).WithMany(p => p.Bills).HasForeignKey(p => p.UserId);
        }
    }
}
