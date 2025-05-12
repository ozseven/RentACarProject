using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Api.Domain.Models;
using RentACar.Common.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Utilities
{
    /// <summary>
    /// Veritabanında bir varlığın (entity) mevcut olup olmadığını kontrol etmek için kullanılan yardımcı sınıf.
    /// </summary>
    /// <typeparam name="Entity">Kontrol edilecek varlığın türü (BaseEntity'den türemelidir).</typeparam>
    public class ExistsDatabaseQuery<Entity>
            where Entity : BaseEntity
    {
        /// <summary>
        /// Belirtilen koşula uyan bir varlığın veritabanında olup olmadığını asenkron olarak kontrol eder.
        /// </summary>
        /// <param name="_repository">Veritabanı erişimi için kullanılan repository.</param>
        /// <param name="method">Varlığın kontrolü için kullanılacak LINQ ifadesi (Expression).</param>
        /// <returns>Varlık mevcutsa `true`, aksi takdirde `DatabaseExistingValueException` fırlatır.</returns>
        public static async Task<bool> IsExistingAsync(IBaseRepository<Entity> _repository, Expression<Func<Entity, bool>> method)
        {
            var IsExisting = await _repository.GetSingleAsync(method);
            if (IsExisting != null)
            {
                throw new DatabaseExistingValueException("This value is already in use in the database!");
            }
            return true;
        }
    }
}
