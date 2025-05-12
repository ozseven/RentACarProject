using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentACar.Api.Domain;
using RentACar.Api.Domain.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace RentACar.Infrastructure.Persistance.Context
{
    public class RentACarContext:DbContext
    {
        public const string DEFAULT_SCHEMA = "dbo";

        public RentACarContext()
        {

        }

        public RentACarContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=postgres;Port=5432;Database=rentacardb;Username=RentACarRootUser;Password=lh9P0U5ClWryCmD2LKdkvhL2j;");
            }
        }

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Rent> Rent { get; set; }
        public DbSet<RentOffice> RentOffice { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSave();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSave()
        {
            var addedEntites = ChangeTracker.Entries()
                                    .Where(i => i.State == EntityState.Added)
                                    .Select(i => (BaseEntity)i.Entity);

            PrepareAddedEntities(addedEntites);

            var updatedEntites = ChangeTracker.Entries()
                .Where(i => i.State == EntityState.Modified)
                .Select(i => (BaseEntity)i.Entity);

            PrepareUpdatedEntities(updatedEntites);
        }

        private void PrepareAddedEntities(IEnumerable<BaseEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.CreatedDate == DateTime.MinValue)
                    entity.CreatedDate = DateTime.UtcNow;
                    entity.UpdatedDate = DateTime.UtcNow;
            }
        }
        private void PrepareUpdatedEntities(IEnumerable<BaseEntity> entities)
        {
            foreach (var item in entities)
            {
                if (item.UpdatedDate == DateTime.MinValue)
                    item.UpdatedDate = DateTime.UtcNow;
            }
        }
    }
}
