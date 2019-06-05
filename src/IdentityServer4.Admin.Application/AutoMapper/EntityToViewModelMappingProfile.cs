using AutoMapper;
using IdentityServer4.Admin.Application.ViewModels;
using IdentityServer4.Admin.Identity.Entities;

namespace IdentityServer4.Admin.Application.AutoMapper
{
    public class EntityToViewModelMappingProfile : Profile
    {
        public EntityToViewModelMappingProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>();
        }
    }
}
