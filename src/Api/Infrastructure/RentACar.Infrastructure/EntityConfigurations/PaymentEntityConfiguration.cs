using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Api.Domain.Models;
using RentACar.Infrastructure.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Persistance.EntityConfigurations
{
    public class PaymentEntityConfiguration:BaseEntityConfiguration<Payment>
    {
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            base.Configure(builder);
            builder.ToTable("payment", RentACarContext.DEFAULT_SCHEMA);

            builder.HasOne(x => x.Rent)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.RentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
