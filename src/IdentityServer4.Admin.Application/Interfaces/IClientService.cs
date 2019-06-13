﻿using IdentityServer4.Admin.Application.ViewModels;
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
    }
}
