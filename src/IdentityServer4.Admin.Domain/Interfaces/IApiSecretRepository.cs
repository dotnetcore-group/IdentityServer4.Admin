using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Domain.Interfaces
{
    public interface IApiSecretRepository : IRepository<ApiSecret>, IAsyncRepository<ApiSecret>
    {
        Task<IEnumerable<ApiSecret>> FindByApiResourceNameAsync(string name);
    }
}
