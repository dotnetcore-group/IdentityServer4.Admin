using AutoMapper;
using IdentityServer4.Admin.Application.ViewModels;
using IdentityServer4.Admin.Application.ViewModels.ApiResource;
using IdentityServer4.Admin.Identity.Entities;
using IdentityServer4.EntityFramework.Entities;

namespace IdentityServer4.Admin.Application.AutoMapper
{
    public class EntityToViewModelMappingProfile : Profile
    {
        public EntityToViewModelMappingProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>();

            CreateMap<ApiResource, ApiResourceViewModel>();

            CreateMap<ApiSecret, SecretViewModel>(MemberList.Destination);

            CreateMap<ApiScope, ScopeViewModel>();

            CreateMap<UserClaim, ClaimViewModel>(MemberList.Destination);
        }
    }
}
