using IdentityServer4.Admin.Application.ViewModels.Client;
using IdentityServer4.Admin.BuildingBlock.Mvc;
using IdentityServer4.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.AdminUI.Apis
{
    [Headers("Authorization: Bearer")]
    public interface IClientsApi
    {
        [Get("/clients")]
        Task<JsonResponse<IList<ClientViewModel>>> GetClientsAsync();

        [Get("/clients/{clientId}")]
        Task<JsonResponse<Client>> GetClientDetailsAsync(string clientId);
    }
}
