using IdentityServer4.Admin.Application.ViewModels.Client;
using IdentityServer4.Admin.BuildingBlock.Mvc;
using IdentityServer4.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer4.AdminUI.Apis
{

    public interface IClientsApi : IApi
    {
        [Get("/clients")]
        Task<JsonResponse<IList<ClientViewModel>>> GetClientsAsync();

        [Get("/clients/{clientId}")]
        Task<JsonResponse<Client>> GetClientDetailsAsync(string clientId);
    }
}
