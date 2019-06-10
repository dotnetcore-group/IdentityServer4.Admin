using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Application.Interfaces
{
    public interface IClientService
    {
        Task<IList<Client>> GetClientsAsync();
        Task<Client> GetClientDetails(string clientId);
    }
}
