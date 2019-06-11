using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Domain.Interfaces
{
    public interface IApiResourceRepository : IRepository<ApiResource>, IAsyncRepository<ApiResource>
    {
        Task<List<ApiResource>> GetApiResourcesAsync();
        Task<ApiResource> FindByNameAsync(string name);
    }
}
