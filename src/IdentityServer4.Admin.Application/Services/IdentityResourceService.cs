using AutoMapper;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.ViewModels.IdentityResource;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.EntityFramework.Mappers;
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
        public IdentityResourceService(IIdentityResourceRepository identityResourceRepository,
            IMapper mapper)
        {
            _identityResourceRepository = identityResourceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IdentityResourceViewModel>> GetIdentityResourcesAsync()
        {
            var resources = await _identityResourceRepository.FindAsync(r => true);
            return _mapper.Map<IEnumerable<IdentityResourceViewModel>>(resources);
        }
    }
}
