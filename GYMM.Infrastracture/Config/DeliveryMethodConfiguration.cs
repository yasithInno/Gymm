using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GYMM.Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace GYMM.Infrastracture.Config
{
    public class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.Property(p=>p.Price).HasColumnType("decimal(18,2)");
        }
    }
}
