using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class, new()
    {
        TEntity Add(TEntity entity);
        TEntity FindById<TPrimary>(TPrimary id) where TPrimary : struct;
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> where);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        int SaveChanges();
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where);
    }

    public interface IAsyncRepository<TEntity> : IDisposable
        where TEntity : class, new()
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> FindByIdAsync<TPrimary>(TPrimary id) where TPrimary : struct;
        Task<IQueryable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> where);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task<int> SaveChangesAsync();
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> where);
    }
}
