using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Models.Interfaces;

namespace DAL.Interfaces
{
    public interface IBaseRepository<TEntity, TKey> : IDisposable where TEntity : class, IEntity<TKey>
    {
        Task CreateAsync(TEntity entity);

        Task CreateManyAsync(ICollection<TEntity> items);

        IEnumerable<TEntity> ReadMany(string include = null);

        Task<TEntity> ReadAsync(TKey id, string include);

        Task<IEnumerable<TEntity>> FindManyAsync(Func<TEntity, bool> predicate, string include);

        Task<TEntity> FindFirstAsync(Func<TEntity, bool> predicate);

        void Update(/*TKey id, */TEntity entityToUpdate);

        IEnumerable<TEntity> GetManyAsync(Expression<Func<TEntity, bool>> filter = null,
                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                          string includeProperties = "");

        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");

        Task DeleteAsync(TKey id);

        Task<bool> Exist(Expression<Func<TEntity, bool>> predicate);

        Task<bool> SaveAsync();
    }
}
