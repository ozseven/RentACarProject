using Microsoft.EntityFrameworkCore;
using RentACar.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Interfaces.Repositories
{
    /// <summary>
    /// Temel veritabanı işlemleri için arayüz.
    /// CRUD operasyonlarını ve temel sorgulama işlemlerini tanımlar.
    /// </summary>
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        // Read operations
        DbSet<TEntity> Table { get; }
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method,
                                     params Expression<Func<TEntity, object>>[] includes);

        // Write operations
        Task<bool> AddRangeAsync(List<TEntity> model);
        bool Remove(TEntity model);
        Task<bool> RemoveAsync(Guid id);
        bool Update(TEntity model);
        Task<int> SaveChangesAsync();
    }
}
