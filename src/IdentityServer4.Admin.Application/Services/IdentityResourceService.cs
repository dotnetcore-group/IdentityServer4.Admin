using AutoMapper;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.ViewModels.IdentityResource;
using IdentityServer4.Admin.Domain.Commands.IdentityResource;
using IdentityServer4.Admin.Domain.Core.Bus;
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
    public class IdentityResourceService : IIdentityResourceService
    {
        private readonly IIdentityResourceRepository _identityResourceRepository;
        private readonly IMapper _mapper;
        public IMediatorHandler _bus { get; set; }
        public IdentityResourceService(IIdentityResourceRepository identityResourceRepository,
            IMapper mapper,
            IMediatorHandler bus)
        {
            _identityResourceRepository = identityResourceRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public async Task CreateAsync(CreateIdentityResourceViewModel vm)
        {
            var model = _mapper.Map<IdentityResource>(vm);
            var command = _mapper.Map<CreateIdentityResourceCommand>(model);
            await _bus.SendCommand(command);
        }

        public async Task<IdentityResource> GetIdentityResourceAsync(string name)
        {
            var resource = await _identityResourceRepository.FindByNameAsync(name);
            return resource?.ToModel();
        }

        public async Task<IEnumerable<IdentityResourceViewModel>> GetIdentityResourcesAsync()
        {
            var resources = await _identityResourceRepository.FindAsync(r => true);
            return _mapper.Map<IEnumerable<IdentityResourceViewModel>>(resources);
        }

        public async Task RemoveAsync(string name)
        {
            var command = new RemoveIdentityResourceCommand(name);
            await _bus.SendCommand(command);
        }

        public async Task UpdateAsync(UpdateIdentityResourceViewModel model)
        {
            var command = _mapper.Map<UpdateIdentityResourceCommand>(model);
            await _bus.SendCommand(command);
        }
    }
}
