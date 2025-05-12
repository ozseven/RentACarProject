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
    public class RentEntityConfiguration:BaseEntityConfiguration<Rent>
    {
        public override void Configure(EntityTypeBuilder<Rent> builder)
        {
            base.Configure(builder);
            builder.ToTable("rent", RentACarContext.DEFAULT_SCHEMA);
            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Rents)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.RentOffice)
                .WithMany(x => x.Rents)
                .HasForeignKey(x => x.RentOfficeId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Products)
                .WithMany(x => x.Rents)
                .UsingEntity(j => j.ToTable("product_rent"));
            builder.HasMany(x => x.Payments)
                .WithOne(x => x.Rent)
                .HasForeignKey(x => x.RentId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.Rents)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
