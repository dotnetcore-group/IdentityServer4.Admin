using AutoMapper;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private IMapper _mapper;
        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<IList<Client>> GetClientsAsync()
        {
            return _mapper.Map<IList<Client>>((await _clientRepository.FindAsync(c => true)
                .ConfigureAwait(false))
                .ToList());
        }

        public async Task<Client> GetClientDetails(string clientId)
        {
            var client = await _clientRepository.GetClient(clientId);
            return _mapper.Map<Client>(client);
        }
    }
}
