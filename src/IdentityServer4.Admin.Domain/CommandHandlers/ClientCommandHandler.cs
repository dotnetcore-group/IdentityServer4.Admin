using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IdentityServer4.Admin.Domain.Commands.Client;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Notifications;
using IdentityServer4.Admin.Domain.Events.Client;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.EntityFramework.Mappers;
using MediatR;

namespace IdentityServer4.Admin.Domain.CommandHandlers
{
    public class ClientCommandHandler : CommandHandler,
        IRequestHandler<CreateClientCommand, bool>,
        IRequestHandler<RemoveClientCommand, bool>,
        IRequestHandler<UpdateClientCommand, bool>
    {

        private readonly IClientRepository _clientRepository;
        public ClientCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications,
            IClientRepository clientRepository)
            : base(uow, bus, notifications)
        {
            _clientRepository = clientRepository;
        }

        public async Task<bool> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var existed = await _clientRepository.ExistedAsync(request.Client.ClientId);
            if (existed)
            {
                await _bus.RaiseEvent(new DomainNotification("key_already_existed", $"Client named {request.Client.ClientId} already exists"));
                return false;
            }

            var client = request.GetClientEntity();

            await _clientRepository.AddAsync(client);

            if (Commit())
            {
                await _bus.RaiseEvent(new ClientCreatedEvent(client.ClientId, client.ClientName, request.ClientType));
                return true;
            }

            return false;
        }

        public async Task<bool> Handle(RemoveClientCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var client = await _clientRepository.FindByClientIdAsync(request.Client.ClientId);
            if (client == null)
            {
                await _bus.RaiseEvent(new DomainNotification("key_not_found", $"Client with ClientId {request.Client.ClientId} not found"));
                return false;
            }
            await _clientRepository.RemoveAsync(client);
            if (Commit())
            {
                await _bus.RaiseEvent(new ClientRemovedEvent(client.ClientId));
                return true;
            }

            return false;
        }

        public async Task<bool> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }
            var clientId = request.OriginalClinetId != request.Client.ClientId ? request.OriginalClinetId : request.Client.ClientId;
            var client = await _clientRepository.FindByClientIdAsync(clientId);
            if (client == null)
            {
                await _bus.RaiseEvent(new DomainNotification("key_not_found", $"Client with ClientId {clientId} not found"));
                return false;
            }
            var entity = request.Client.ToEntity();
            entity.Id = client.Id;
            await _clientRepository.UpdateWithChildrensAsync(entity);

            if(Commit())
            {
                await _bus.RaiseEvent(new ClientUpdatedEvent(request));
                return true;
            }

            return false;
        }
    }
}
