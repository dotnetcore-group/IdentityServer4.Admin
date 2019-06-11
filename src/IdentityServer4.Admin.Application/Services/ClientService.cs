using AutoMapper;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.ViewModels.Client;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.EntityFramework.Mappers;
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

        public async Task<IList<ClientViewModel>> GetClientsAsync()
        {
            var clients = await _clientRepository.FindAsync(c => true);
            return _mapper.Map<IList<ClientViewModel>>(clients?.Select(c => c.ToModel()));
        }

        public async Task<Client> GetClientDetails(string clientId)
        {
            var client = await _clientRepository.GetClientAsync(clientId);
            return _mapper.Map<Client>(client);
        }
    }
}
