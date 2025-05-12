using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Persistance.EntityConfigurations
{
    public abstract class BaseEntityConfiguration<Entity> : IEntityTypeConfiguration<Entity> where Entity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e=>e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.CreatedDate).ValueGeneratedOnAdd();
            builder.Property(e=>e.UpdatedDate).ValueGeneratedOnAdd();
        }
    }
}
