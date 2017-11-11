using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Models.Interfaces;

namespace DAL.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class, IEntity
    {
        Task CreateAsync(TEntity entity);

        Task CreateManyAsync(ICollection<TEntity> items);

        IEnumerable<TEntity> ReadMany(string include = null);

        Task<TEntity> ReadAsync(int id, string include);

        Task<IEnumerable<TEntity>> FindManyAsync(Func<TEntity, bool> predicate, string include);

        Task<TEntity> FindFirstAsync(Func<TEntity, bool> predicate);

        void Update(int id, TEntity entityToUpdate);

        IEnumerable<TEntity> GetManyAsync(Expression<Func<TEntity, bool>> filter = null,
                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                          string includeProperties = "");

        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");

        Task DeleteAsync(int id);

        Task<bool> Exist(Expression<Func<TEntity, bool>> predicate);

        Task<bool> SaveAsync();
    }
}
