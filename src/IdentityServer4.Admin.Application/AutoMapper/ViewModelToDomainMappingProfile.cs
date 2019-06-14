using AutoMapper;
using IdentityServer4.Admin.Application.ViewModels;
using IdentityServer4.Admin.Application.ViewModels.ApiResource;
using IdentityServer4.Admin.Application.ViewModels.Client;
using IdentityServer4.Admin.Application.ViewModels.User;
using IdentityServer4.Admin.Domain.Commands;
using IdentityServer4.Admin.Domain.Commands.ApiResource;
using IdentityServer4.Admin.Domain.Commands.Client;
using IdentityServer4.Admin.Domain.Commands.User;
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
            CreateMap<SocialViewModel, AddLoginCommand>(MemberList.Source)
                .ConstructUsing(c => new AddLoginCommand(c.Username, c.Provider, c.ProviderId));

            CreateMap<RegisterUserViewModel, RegisterNewUserCommand>(MemberList.Source)
                .ConstructUsing(c => new RegisterNewUserCommand(c.Email, c.Password, c.ConfirmPassword));
            CreateMap<CreateUserViewModel, CreateUserCommand>()
                .ConstructUsing(c => new CreateUserCommand(c.UserName, c.Email, c.Nickname, c.Password, c.ConfirmPassword, c.EmailConfirmed));

            CreateMap<SetApiSecretViewModel, SetApiSecretCommand>(MemberList.Source)
                .ConstructUsing(c => new SetApiSecretCommand(c.ApiResourceName, c.Description, c.Value, c.Type, c.Expiration, (int)c.HashType.GetValueOrDefault(HashType.Sha256)));
            CreateMap<SetApiScopeViewModel, SetApiScopeCommand>()
                .ConstructUsing(c => new SetApiScopeCommand(c.ApiResourceName, c.Name, c.DisplayName, c.Description, c.Required, c.Emphasize, c.ShowInDiscoveryDocument, c.UserClaims));

            CreateMap<CreateClientViewModel, CreateClientCommand>()
                .ConstructUsing(c => new CreateClientCommand(c.ClientId, c.ClientName, c.ClientUri, c.Description, c.LogoUri, c.ClientType));
            CreateMap<UpdateClientViewModel, UpdateClientCommand>()
                .ConstructUsing(c => new UpdateClientCommand(c, c.OriginalClinetId));
        }
    }
}
