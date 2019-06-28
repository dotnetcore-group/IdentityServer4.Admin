using AutoMapper;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.ViewModels;
using IdentityServer4.Admin.Application.ViewModels.Client;
using IdentityServer4.Admin.Domain.Commands.Client;
using IdentityServer4.Admin.Domain.Commands.Client.Claim;
using IdentityServer4.Admin.Domain.Commands.Client.Property;
using IdentityServer4.Admin.Domain.Commands.Client.Secret;
using IdentityServer4.Admin.Domain.Core.Bus;
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
        private readonly IClientPropertyRepository _clientPropertyRepository;
        private readonly IClientSecretRepository _clientSecretRepository;
        private readonly IClientClaimRepository _clientCliamRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        public ClientService(IClientRepository clientRepository,
            IClientSecretRepository clientSecretRepository,
            IClientClaimRepository clientCliamRepository,
            IClientPropertyRepository clientPropertyRepository,
            IMapper mapper, IMediatorHandler bus)
        {
            _clientRepository = clientRepository;
            _clientSecretRepository = clientSecretRepository;
            _clientCliamRepository = clientCliamRepository;
            _clientPropertyRepository = clientPropertyRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public async Task<IList<ClientViewModel>> GetClientsAsync()
        {
            var clients = await _clientRepository.FindAsync(c => true);
            return _mapper.Map<IList<ClientViewModel>>(clients?.Select(c => c.ToModel()));
        }

        public async Task<Client> GetClientDetails(string clientId)
        {
            var client = await _clientRepository.GetClientAsync(clientId);
            return client?.ToModel();
        }

        public async Task CreateAsync(CreateClientViewModel model)
        {
            var command = _mapper.Map<CreateClientCommand>(model);
            await _bus.SendCommand(command);
        }

        public async Task RemoveAsync(string clientId)
        {
            var command = new RemoveClientCommand(clientId);
            await _bus.SendCommand(command);
        }

        public async Task UpdateAsync(UpdateClientViewModel model)
        {
            var command = _mapper.Map<UpdateClientCommand>(model);
            await _bus.SendCommand(command);
        }

        public async Task<IEnumerable<SecretViewModel>> GetSecretsAsync(string clientId)
        {
            var secrets = await _clientSecretRepository.FindByClientIdAsync(clientId);
            return _mapper.Map<IEnumerable<SecretViewModel>>(secrets);
        }

        public async Task<IEnumerable<ClaimViewModel>> GetClaimsAsync(string clientId)
        {
            var claims = await _clientCliamRepository.FindByClientIdAsync(clientId);
            return _mapper.Map<IEnumerable<ClaimViewModel>>(claims);
        }

        public async Task<IEnumerable<PropertyViewModel>> GetPropertiesAsync(string clientId)
        {
            var properties = await _clientPropertyRepository.FindByClientIdAsync(clientId);
            return _mapper.Map<IEnumerable<PropertyViewModel>>(properties);
        }

        public async Task RemovePropertiesAsync(string clientId, int id)
        {
            var command = new RemoveClientPropertyCommand(clientId, id);
            await _bus.SendCommand(command);
        }

        public async Task SavePropertyAsync(string clientId, SaveClientPropertyViewModel model)
        {
            model.ClientId = clientId;
            var command = _mapper.Map<SaveClientPropertyCommand>(model);
            await _bus.SendCommand(command);
        }

        public async Task RemoveSecretAsync(string clientId, int id)
        {
            var command = new RemoveClientSecretCommand(clientId, id);
            await _bus.SendCommand(command);
        }

        public async Task SaveSecretAsync(SaveClientSecretViewModel model)
        {
            var command = _mapper.Map<SaveClientSecretCommand>(model);
            await _bus.SendCommand(command);
        }

        public async Task RemoveClaimAsync(string clientId, int id)
        {
            var command = new RemoveClientClaimCommand(clientId, id);
            await _bus.SendCommand(command);
        }

        public async Task SaveClaimAsync(SaveClientClaimViewModel model)
        {
            var command = _mapper.Map<SaveClientClaimCommand>(model);
            await _bus.SendCommand(command);
        }

        public Task<int> GetTotalClientsAsync()
        {
            return _clientRepository.CountAsync();
        }
    }
}
