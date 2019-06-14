using AutoMapper;
using IdentityServer4.Admin.Domain.Entities;
using IdentityServer4.Admin.Domain.Events.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Application.AutoMapper
{
    public class EventToEntityMappingProfile : Profile
    {
        public EventToEntityMappingProfile()
        {
            CreateMap<UserLoggedInEvent, UserLoginLog>(MemberList.Destination);
        }
    }
}
