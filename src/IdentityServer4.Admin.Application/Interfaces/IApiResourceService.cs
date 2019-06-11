using IdentityServer4.Admin.Application.ViewModels;
using IdentityServer4.Admin.Application.ViewModels.ApiResource;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Application.Interfaces
{
    public interface IApiResourceService
    {
        Task<IEnumerable<ApiResourceViewModel>> GetApiResourcesAsync();
        Task<ApiResource> GetApiResourceAsync(string name);
        Task AddAsync(ApiResource apiResource);
        Task UpdateAsync(ApiResource apiResource);
        Task RemoveAsync(RemoveApiResourceViewModel vm);
        Task<IEnumerable<SecretViewModel>> GetSecretsAsync(string name);
        Task RemoveSecrectAsync(RemoveApiSecretViewModel vm);
        Task SetSecretAsync(SetApiSecretViewModel vm);
        Task<IEnumerable<ScopeViewModel>> GetScopesAsync(string name);
        Task RemoveScopeAsync(RemoveApiScopeViewModel vm);
        Task SetScopeAsync(SetApiScopeViewModel vm);
    }
}
