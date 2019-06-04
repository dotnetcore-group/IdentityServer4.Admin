using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IList<Client>> GetClientsAsync()
        {
            return await _clientRepository.QueryAsync(null).ConfigureAwait(false);
        }
    }
}
