using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Admin.Infrastructures.Data.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>, 
        IAsyncRepository<TEntity> 
        where TEntity : class, new()
    {
        protected readonly IDS4DbContext DbContext;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(IDS4DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            var entry = DbContext.Add(entity);

            return entry.Entity;
        }

        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where(where);
        }

        public TEntity FindById<TPrimary>(TPrimary id) where TPrimary : struct
        {
            return DbSet.Find(id);
        }

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        #region Async Methods
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var entry = await DbSet.AddAsync(entity);
            return entry.Entity;
        }

        public Task<IQueryable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> where)
        {
            return Task.FromResult(DbSet.Where(where));
        }

        public Task<TEntity> FindByIdAsync<TPrimary>(TPrimary id) where TPrimary : struct
        {
            return DbSet.FindAsync(id);
        }

        public Task RemoveAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<int> SaveChangesAsync()
        {
            return DbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            return Task.CompletedTask;
        } 
        #endregion
    }
}
