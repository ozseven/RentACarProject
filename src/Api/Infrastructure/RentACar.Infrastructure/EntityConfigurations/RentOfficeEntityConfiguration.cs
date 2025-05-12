using Microsoft.EntityFrameworkCore;
using RentACar.Api.Domain.Models;
using RentACar.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Persistance.EntityConfigurations
{
    public class RentOfficeEntityConfiguration:BaseEntityConfiguration<RentOffice>
    {
        public override void Configure(EntityTypeBuilder<RentOffice> builder)
        {
            base.Configure(builder);
            builder.ToTable("rent_office", RentACarContext.DEFAULT_SCHEMA);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.RentOffice)
                .HasForeignKey(x => x.RentOfficeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
