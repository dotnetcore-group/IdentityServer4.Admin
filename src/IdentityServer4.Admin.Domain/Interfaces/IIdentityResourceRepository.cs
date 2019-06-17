using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Domain.Interfaces
{
    public interface IIdentityResourceRepository : IRepository<IdentityResource>, IAsyncRepository<IdentityResource>
    {
        Task<IdentityResource> FindByNameAsync(string name);
        Task UpdateWithChildrensAsync(IdentityResource resource);
    }
}
