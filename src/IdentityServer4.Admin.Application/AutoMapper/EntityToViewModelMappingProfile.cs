using AutoMapper;
using IdentityServer4.Admin.Application.ViewModels;
using IdentityServer4.Admin.Application.ViewModels.ApiResource;
using IdentityServer4.Admin.Application.ViewModels.Client;
using IdentityServer4.Admin.Application.ViewModels.IdentityResource;
using IdentityServer4.Admin.Application.ViewModels.Role;
using IdentityServer4.Admin.Application.ViewModels.User;
using IdentityServer4.Admin.Identity.Entities;
using IdentityServer4.EntityFramework.Entities;

namespace IdentityServer4.Admin.Application.AutoMapper
{
    public class EntityToViewModelMappingProfile : Profile
    {
        public EntityToViewModelMappingProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>(MemberList.Destination);
            CreateMap<ApplicationUser, PagingUserViewModel>(MemberList.Destination);

            CreateMap<ApplicationRole, RoleViewModel>(MemberList.Destination);

            CreateMap<ApiResource, ApiResourceViewModel>();

            CreateMap<ApiSecret, SecretViewModel>(MemberList.Destination);

            CreateMap<ApiScope, ScopeViewModel>();

            CreateMap<UserClaim, ClaimViewModel>(MemberList.Destination);

            CreateMap<Models.Client, ClientViewModel>(MemberList.Destination);

            CreateMap<IdentityResource, IdentityResourceViewModel>(MemberList.Destination);

        }
    }
}
