using IdentityServer4.Admin.Application.ViewModels.IdentityResource;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Application.Interfaces
{
    public interface IIdentityResourceService
    {
        Task<IEnumerable<IdentityResourceViewModel>> GetIdentityResourcesAsync();
        Task<IdentityResource> GetIdentityResourceAsync(string name);
        Task CreateAsync(CreateIdentityResourceViewModel model);
        Task RemoveAsync(string name);
        Task UpdateAsync(UpdateIdentityResourceViewModel model);
    }
}
