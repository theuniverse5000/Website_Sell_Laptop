﻿using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ProductDetailConfigurations : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.ToTable("ProductDetail");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Ma).HasColumnType("nvarchar(100)");
            builder.Property(p => p.Description).HasColumnType("nvarchar(100)");
            builder.Property(p => p.ImportPrice).HasColumnType("decimal");
            builder.Property(p => p.Price).HasColumnType("decimal");
            builder.HasOne(p => p.Product).WithMany(p => p.ProductDetails).
              HasForeignKey(p => p.IdProduct);
            builder.HasOne(p => p.Color).WithMany(p => p.ProductDetails).
               HasForeignKey(p => p.IdColor);
            builder.HasOne(p => p.Cpu).WithMany(p => p.ProductDetails).
             HasForeignKey(p => p.IdCpu);
            builder.HasOne(p => p.Ram).WithMany(p => p.ProductDetails).
             HasForeignKey(p => p.IdRam);
            builder.HasOne(p => p.HardDrive).WithMany(p => p.ProductDetails).
             HasForeignKey(p => p.IdHardDrive);
            builder.HasOne(p => p.CardVGA).WithMany(p => p.ProductDetails).
           HasForeignKey(p => p.IdCardVGA);
            builder.HasOne(p => p.Screen).WithMany(p => p.ProductDetails).
         HasForeignKey(p => p.IdScreen);


        }
    }
}
