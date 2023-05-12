﻿using Sell_Laptop_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sell_Laptop_API.Configurations
{
    public class CartDetailConfigurations : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.ToTable("CartDetail");
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.Cart).WithMany(p => p.CartDetails).
                HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.ProductDetail).WithMany(p => p.CartDetails).
                HasForeignKey(p => p.IdProductDetails);
        }
    }
}
