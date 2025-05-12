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
    public class ProductEntityConfiguration: BaseEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.ToTable("product", RentACarContext.DEFAULT_SCHEMA);
            builder.HasOne(x => x.RentOffice)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.RentOfficeId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Rents)
                .WithMany(x => x.Products)
                .UsingEntity(j => j.ToTable("product_rent"));

        }
    }
}
