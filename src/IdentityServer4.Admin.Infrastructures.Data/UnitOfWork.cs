using System.Threading.Tasks;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Admin.Infrastructures.Data.Database;

namespace IdentityServer4.Admin.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IS4DbContext _dbContext;
        public UnitOfWork(IS4DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Commit()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public async Task<bool> CommitAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 0;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
