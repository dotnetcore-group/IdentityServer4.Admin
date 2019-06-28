using IdentityServer4.Admin.Application.ViewModels;
using IdentityServer4.Admin.Application.ViewModels.Client;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Application.Interfaces
{
    public interface IClientService
    {
        Task<IList<ClientViewModel>> GetClientsAsync();
        Task<Client> GetClientDetails(string clientId);
        Task CreateAsync(CreateClientViewModel model);
        Task RemoveAsync(string clientId);
        Task UpdateAsync(UpdateClientViewModel model);
        Task<IEnumerable<SecretViewModel>> GetSecretsAsync(string clientId);
        Task<IEnumerable<ClaimViewModel>> GetClaimsAsync(string clientId);
        Task<IEnumerable<PropertyViewModel>> GetPropertiesAsync(string clientId);
        Task RemovePropertiesAsync(string clientId, int id);
        Task SavePropertyAsync(string clientId, SaveClientPropertyViewModel model);
        Task RemoveSecretAsync(string clientId, int id);
        Task SaveSecretAsync(SaveClientSecretViewModel model);
        Task RemoveClaimAsync(string clientId, int id);
        Task SaveClaimAsync(SaveClientClaimViewModel model);
        Task<int> GetTotalClientsAsync();
    }
}
