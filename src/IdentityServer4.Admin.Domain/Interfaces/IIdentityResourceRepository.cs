using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Interfaces
{
    public interface IIdentityResourceRepository : IRepository<IdentityResource>, IAsyncRepository<IdentityResource>
    {
    }
}
