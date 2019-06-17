using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IdentityServer4.Admin.Domain.Commands.IdentityResource;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Notifications;
using IdentityServer4.Admin.Domain.Events.IdentityResource;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.EntityFramework.Mappers;
using MediatR;

namespace IdentityServer4.Admin.Domain.CommandHandlers
{
    public class IdentityResourceCommandHandler : CommandHandler,
        IRequestHandler<CreateIdentityResourceCommand, bool>,
        IRequestHandler<UpdateIdentityResourceCommand, bool>,
        IRequestHandler<RemoveIdentityResourceCommand, bool>
    {
        private readonly IIdentityResourceRepository _identityResourceRepository;

        public IdentityResourceCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications,
            IIdentityResourceRepository identityResourceRepository) : base(uow, bus, notifications)
        {
            _identityResourceRepository = identityResourceRepository;
        }

        public async Task<bool> Handle(CreateIdentityResourceCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var existed = await _identityResourceRepository.FirstOrDefaultAsync(c => c.Name == request.IdentityResource.Name) != null;
            if (existed)
            {
                await _bus.RaiseEvent(new DomainNotification("key_already_existed", $"IdentityResource named {request.IdentityResource.Name} already existed"));
                return false;
            }

            var resource = request.IdentityResource.ToEntity();
            await _identityResourceRepository.AddAsync(resource);
            if (Commit())
            {
                await _bus.RaiseEvent(new IdentityResourceCreatedEvent(resource.Id, resource.Name));
                return true;
            }
            return false;
        }

        public async Task<bool> Handle(RemoveIdentityResourceCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var resource = await _identityResourceRepository.FirstOrDefaultAsync(r => r.Name == request.IdentityResource.Name);
            if (resource != null)
            {
                await _identityResourceRepository.RemoveAsync(resource);
                if (Commit())
                {
                    await _bus.RaiseEvent(new IdentityResourceRemovedEvent(resource.Id));
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Handle(UpdateIdentityResourceCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }
            var name = request.OldIdentityResourceName != request.IdentityResource.Name ? request.OldIdentityResourceName : request.IdentityResource.Name;
            var resource = await _identityResourceRepository.FirstOrDefaultAsync(r => r.Name == name);
            if (resource == null)
            {
                await _bus.RaiseEvent(new DomainNotification("key_not_found", $"IdentityResource named {name} could not be found"));
                return false;
            }
            var vm = request.IdentityResource.ToEntity();
            resource.Name = vm.Name;
            resource.DisplayName = vm.DisplayName;
            resource.Description = vm.Description;
            resource.Enabled = vm.Enabled;
            resource.Emphasize = vm.Emphasize;
            resource.ShowInDiscoveryDocument = vm.ShowInDiscoveryDocument;
            resource.Properties = vm.Properties;
            resource.Required = vm.Required;
            resource.Updated = DateTime.UtcNow;
            resource.UserClaims = vm.UserClaims;

            await _identityResourceRepository.UpdateWithChildrensAsync(resource);
            if (Commit())
            {
                await _bus.RaiseEvent(new IdentityResourceUpdatedEvent(resource.Id, request.IdentityResource.Name, request.OldIdentityResourceName));
                return true;
            }
            return false;
        }
    }
}
