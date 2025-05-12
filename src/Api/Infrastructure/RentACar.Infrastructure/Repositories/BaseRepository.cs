using Microsoft.EntityFrameworkCore;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Api.Domain.Models;
using RentACar.Infrastructure.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Persistance.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly RentACarContext _context;

        public BaseRepository(RentACarContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        // Read Methods
        public IQueryable<TEntity> GetAll()
            => Table.Where(i => !i.IsDeleted);

        public async Task<TEntity> GetByIdAsync(Guid id)
            => await Table.FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted);

        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method)
            => Table.Where(i => !i.IsDeleted).Where(method);

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method,
                                                  params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = Table.Where(method).Where(i => !i.IsDeleted);
            foreach (var include in includes)
                query = query.Include(include);
            return await query.SingleOrDefaultAsync();
        }

        // Write Methods

        public async Task<bool> AddRangeAsync(List<TEntity> model)
        {
            await Table.AddRangeAsync(model);
            return true;
        }

        public bool Remove(TEntity model)
        {
            var entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var result = await Table.SingleOrDefaultAsync(x => x.Id == id);
            result.IsDeleted = true;
            return result!=null && Update(result);
        }

        public bool Update(TEntity model)
        {
            var entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}

