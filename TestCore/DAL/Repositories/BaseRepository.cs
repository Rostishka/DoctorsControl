using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models.Interfaces;
using DAL.Utils;

namespace DAL.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">Create DbSet<TEntity/> that you will work with</typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        internal ApplicationDbContext Context;
        internal DbSet<TEntity> DbSet;

        public BaseRepository(ApplicationDbContext context/*, IMapper mapper*/)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public virtual async Task CreateManyAsync(ICollection<TEntity> items)
        {
            await DbSet.AddRangeAsync(items);
        }

        public virtual IEnumerable<TEntity> ReadMany(string include = null)
        {
            return DbSet.OptionalInclude(include).Select(x => x);
        }

        public virtual async Task<TEntity> ReadAsync(int id, string include)
        {
            return await DbSet.OptionalInclude(include).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual IEnumerable<TEntity> GetManyAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = DbSet.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

             return await query.FirstOrDefaultAsync();
        }


        public virtual async Task<IEnumerable<TEntity>> FindManyAsync(Func<TEntity, bool> predicate, string include)
        {
            var result = Task.FromResult(DbSet.OptionalInclude(include).Where(predicate));
            return await result;
        }

        public virtual async Task<TEntity> FindFirstAsync(Func<TEntity, bool> predicate)
        {
            var result = Task.FromResult(DbSet.FirstOrDefault(predicate));
            return await result;
        }

        public virtual void Update(int id, TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entityToDelete = await DbSet.FindAsync(id);

            if (entityToDelete is null)
                throw new Exception("Item not found");

            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual Task<bool> Exist(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AnyAsync(predicate);
        }

        public virtual async Task<bool> SaveAsync()
        {
            try
            {
                var changes = Context.ChangeTracker.Entries()
                    .Count(p => p.State == EntityState.Modified || p.State == EntityState.Deleted || p.State == EntityState.Added);
                if (changes == 0) return true;
                return await Context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BaseRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}