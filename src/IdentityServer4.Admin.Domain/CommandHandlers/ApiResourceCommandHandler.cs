using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IdentityServer4.Admin.Domain.Commands.ApiResource;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Notifications;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.EntityFramework.Entities;
using MediatR;

namespace IdentityServer4.Admin.Domain.CommandHandlers
{
    public class ApiResourceCommandHandler : CommandHandler,
        IRequestHandler<SetApiSecretCommand, bool>,
        IRequestHandler<SetApiScopeCommand, bool>
    {
        private readonly IApiResourceRepository _apiResourceRepository;
        private readonly IApiSecretRepository _apiSecretRepository;
        private readonly IApiScopeRepository _apiScopeRepository;
        public ApiResourceCommandHandler(IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications,
            IApiResourceRepository apiResourceRepository,
            IApiSecretRepository apiSecretRepository,
            IApiScopeRepository apiScopeRepository)
            : base(uow, bus, notifications)
        {
            _apiResourceRepository = apiResourceRepository;
            _apiSecretRepository = apiSecretRepository;
            _apiScopeRepository = apiScopeRepository;
        }

        public async Task<bool> Handle(SetApiSecretCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var resource = await _apiResourceRepository.FindByNameAsync(request.ApiResourceName);
            if (resource == null)
            {
                await _bus.RaiseEvent(new DomainNotification("key_not_found", $"{request.ApiResourceName} not found"));
                return false;
            }

            var secret = new ApiSecret
            {
                ApiResource = resource,
                Description = request.Description,
                Type = request.Type,
                Expiration = request.Expiration,
                Value = request.GetHashValue()
            };

            await _apiSecretRepository.AddAsync(secret);

            if (Commit())
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Handle(SetApiScopeCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var resource = await _apiResourceRepository.FindByNameAsync(request.ApiResourceName);
            if (resource == null)
            {
                await _bus.RaiseEvent(new DomainNotification("key_not_found", $"{request.ApiResourceName} not found"));
                return false;
            }

            var scope = new ApiScope
            {
                ApiResource = resource,
                Description = request.Description,
                Required = request.Required,
                DisplayName = request.DisplayName,
                Emphasize = request.Emphasize,
                Name = request.Name,
                ShowInDiscoveryDocument = request.ShowInDiscoveryDocument,
                UserClaims = request.UserClaims.Select(s => new ApiScopeClaim() { Type = s }).ToList(),
            };

            await _apiScopeRepository.AddAsync(scope);

            if (Commit())
            {
                return true;
            }

            return false;
        }
    }
}
