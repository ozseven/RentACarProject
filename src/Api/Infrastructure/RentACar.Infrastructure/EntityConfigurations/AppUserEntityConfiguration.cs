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
    public class AppUserEntityConfiguration:BaseEntityConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);
            builder.ToTable("appUser",RentACarContext.DEFAULT_SCHEMA);
            builder.HasOne<RentOffice>(x => x.RentOffice)
                .WithMany(x => x.AppUsers)
                .HasForeignKey(x=>x.RentOfficeId);
        }
    }
}
