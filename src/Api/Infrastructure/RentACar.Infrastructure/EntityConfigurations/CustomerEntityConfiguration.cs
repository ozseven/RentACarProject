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
    public class CustomerEntityConfiguration:BaseEntityConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);
            builder.ToTable("customer", RentACarContext.DEFAULT_SCHEMA);
        }
    }
}
