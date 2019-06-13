using AutoMapper;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.ViewModels;
using IdentityServer4.Admin.Application.ViewModels.ApiResource;
using IdentityServer4.Admin.Domain.Commands.ApiResource;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Notifications;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Application.Services
{
    public class ApiResourceService : IApiResourceService
    {
        private readonly IApiResourceRepository _repository;
        private readonly IApiSecretRepository _secretRepository;
        private readonly IApiScopeRepository _scopeRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        public ApiResourceService(IApiResourceRepository repository,
            IApiSecretRepository secretRepository,
            IApiScopeRepository scopeRepository,
            IMapper mapper,
            IMediatorHandler bus)
        {
            _scopeRepository = scopeRepository;
            _secretRepository = secretRepository;
            _repository = repository;
            _mapper = mapper;
            _bus = bus;
        }

        public async Task<ApiResource> GetApiResourceAsync(string name)
        {
            var resource = await _repository.FindByNameAsync(name);
            if (resource == null)
            {
                await _bus.RaiseEvent(new DomainNotification("name_not_found", $"{name} api resource is not found!"));
            }
            return resource?.ToModel();
        }

        public async Task<IEnumerable<ApiResourceViewModel>> GetApiResourcesAsync()
        {
            var resources = await _repository.GetApiResourcesAsync();
            return resources?.Select(r => _mapper.Map<ApiResourceViewModel>(r));
        }

        public async Task<IEnumerable<ScopeViewModel>> GetScopesAsync(string name)
        {
            var scopes = await _scopeRepository.FindByApiResourceNameAsync(name);
            return scopes?.Select(s => _mapper.Map<ScopeViewModel>(s));
        }

        public async Task<IEnumerable<SecretViewModel>> GetSecretsAsync(string name)
        {
            var secrets = await _secretRepository.FindByApiResourceNameAsync(name);
            return secrets?.Select(r => _mapper.Map<SecretViewModel>(r));
        }

        public async Task RemoveAsync(string name)
        {
            var command = new RemoveApiResourceCommand(name);
            await _bus.SendCommand(command);
        }

        public Task RemoveScopeAsync(RemoveApiScopeViewModel vm)
        {
            throw new NotImplementedException();
        }

        public Task RemoveSecrectAsync(RemoveApiSecretViewModel vm)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(ApiResource apiResource)
        {

        }

        public async Task SetScopeAsync(SetApiScopeViewModel vm)
        {
            var command = _mapper.Map<SetApiScopeCommand>(vm);
            await _bus.SendCommand(command);
        }

        public async Task SetSecretAsync(SetApiSecretViewModel vm)
        {
            var command = _mapper.Map<SetApiSecretCommand>(vm);
            await _bus.SendCommand(command);
        }

        public Task UpdateAsync(ApiResource apiResource)
        {
            throw new NotImplementedException();
        }
    }
}
