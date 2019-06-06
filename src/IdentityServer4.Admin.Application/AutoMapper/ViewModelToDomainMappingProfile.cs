using AutoMapper;
using IdentityServer4.Admin.Application.ViewModels;
using IdentityServer4.Admin.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<SocialViewModel, RegisterNewUserWithoutPassCommand>(MemberList.Source)
                .ConstructUsing(c => new RegisterNewUserWithoutPassCommand(c.Username, c.Email, c.Name, c.Provider, c.ProviderId));
        }
    }
}
