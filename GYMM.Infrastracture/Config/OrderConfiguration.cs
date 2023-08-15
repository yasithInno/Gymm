using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GYMM.Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMM.Infrastracture.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(
            i => i.ItemOrdered,
            io => { io.WithOwner(); });
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        }
    }
}
