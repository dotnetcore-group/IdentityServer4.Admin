using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using IdentityServer4.Admin.Domain.Commands.Client;
using IdentityServer4.Admin.Domain.Commands.Client.Claim;
using IdentityServer4.Admin.Domain.Commands.Client.Property;
using IdentityServer4.Admin.Domain.Commands.Client.Secret;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Notifications;
using IdentityServer4.Admin.Domain.Events.Client;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Mappers;
using MediatR;

namespace IdentityServer4.Admin.Domain.CommandHandlers
{
    public class ClientCommandHandler : CommandHandler,
        IRequestHandler<CreateClientCommand, bool>,
        IRequestHandler<RemoveClientCommand, bool>,
        IRequestHandler<UpdateClientCommand, bool>,
        IRequestHandler<SaveClientPropertyCommand, bool>,
        IRequestHandler<RemoveClientPropertyCommand, bool>,
        IRequestHandler<SaveClientSecretCommand, bool>,
        IRequestHandler<RemoveClientSecretCommand, bool>,
        IRequestHandler<SaveClientClaimCommand, bool>,
        IRequestHandler<RemoveClientClaimCommand, bool>
    {

        private readonly IClientRepository _clientRepository;
        private readonly IClientPropertyRepository _clientPropertyRepository;
        private readonly IClientSecretRepository _clientSecretRepository;
        private readonly IClientClaimRepository _clientClaimRepository;
        public ClientCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications,
            IClientRepository clientRepository,
            IClientPropertyRepository clientPropertyRepository,
            IClientSecretRepository clientSecretRepository,
            IClientClaimRepository clientClaimRepository)
            : base(uow, bus, notifications)
        {
            _clientRepository = clientRepository;
            _clientPropertyRepository = clientPropertyRepository;
            _clientSecretRepository = clientSecretRepository;
            _clientClaimRepository = clientClaimRepository;
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
            var client = await _clientRepository.FindByClientIdWithNoTrackingAsync(clientId);
            if (client == null)
            {
                await _bus.RaiseEvent(new DomainNotification("key_not_found", $"Client with ClientId {clientId} not found"));
                return false;
            }
            var entity = request.Client.ToEntity();
            entity.Id = client.Id;
            await _clientRepository.UpdateWithChildrensAsync(entity);

            if (Commit())
            {
                await _bus.RaiseEvent(new ClientUpdatedEvent(request));
                return true;
            }

            return false;
        }

        /// <summary>
        /// remove client property command handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> Handle(RemoveClientPropertyCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var client = await _clientRepository.GetClientAsync(request.ClientId);
            if (client == null)
            {
                await _bus.RaiseEvent(new DomainNotification("key_not_found", $"Client named {request.ClientId} not found"));
                return false;
            }

            var property = await _clientPropertyRepository.FindByIdAsync(request.Id);
            if (property != null)
            {
                await _clientPropertyRepository.RemoveAsync(property);

                return Commit();
            }

            return true;
        }

        public async Task<bool> Handle(SaveClientPropertyCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var client = await _clientRepository.FindByClientIdAsync(request.ClientId);
            if (client == null)
            {
                await _bus.RaiseEvent(new DomainNotification("key_not_found", $"Client named {request.ClientId} not found"));
                return false;
            }

            var property = new ClientProperty
            {
                Client = client,
                Key = request.Key,
                Value = request.Value
            };

            await _clientPropertyRepository.AddAsync(property);

            if (Commit())
            {
                await _bus.RaiseEvent(new ClientPropertyAddedEvent(request.ClientId, property.Id, request.Key, request.Value));
                return true;
            }

            return false;
        }

        public async Task<bool> Handle(RemoveClientSecretCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var client = await _clientRepository.FindByClientIdAsync(request.ClientId);
            if (client == null)
            {
                await _bus.RaiseEvent(new DomainNotification("key_not_found", $"Client named {request.ClientId} not found"));
                return false;
            }

            var secret = await _clientSecretRepository.FindByIdAsync(request.Id);
            if (secret != null)
            {
                await _clientSecretRepository.RemoveAsync(secret);
                if (Commit())
                {
                    await _bus.RaiseEvent(new ClientSecretRemovedEvent(request.ClientId, request.Id));
                    return true;
                }
            }

            return true;
        }

        public async Task<bool> Handle(SaveClientSecretCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var client = await _clientRepository.FindByClientIdAsync(request.ClientId);
            if (client == null)
            {
                await _bus.RaiseEvent(new DomainNotification("key_not_found", $"Client named {request.ClientId} not found"));
                return false;
            }

            var secret = new ClientSecret
            {
                Client = client,
                Description = request.Description,
                Expiration = request.Expiration,
                Type = request.Type,
                Value = request.GetHashValue()
            };
            await _clientSecretRepository.AddAsync(secret);

            if (Commit())
            {
                await _bus.RaiseEvent(new ClientSecretAddedEvent(request.ClientId, secret.Id, secret.Value, secret.Type, secret.Description));
                return true;
            }
            return false;
        }

        public async Task<bool> Handle(RemoveClientClaimCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var client = await _clientRepository.FindByClientIdAsync(request.ClientId);
            if (client == null)
            {
                await _bus.RaiseEvent(new DomainNotification("key_not_found", $"Client named {request.ClientId} not found"));
                return false;
            }

            var claim = await _clientClaimRepository.FindByIdAsync(request.Id);
            if (claim != null)
            {
                await _clientClaimRepository.RemoveAsync(claim);
                if (Commit())
                {
                    await _bus.RaiseEvent(new ClientClaimRemovedEvent(request.ClientId, request.Id));
                    return true;
                }
            }

            return true;
        }

        public async Task<bool> Handle(SaveClientClaimCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid() == false)
            {
                NotifyValidationErrors(request);
                return false;
            }

            var client = await _clientRepository.FindByClientIdAsync(request.ClientId);
            if (client == null)
            {
                await _bus.RaiseEvent(new DomainNotification("key_not_found", $"Client named {request.ClientId} not found"));
                return false;
            }

            var claim = new ClientClaim
            {
                Client = client,
                Type = request.Type,
                Value = request.Value
            };

            await _clientClaimRepository.AddAsync(claim);
            if (Commit())
            {
                await _bus.RaiseEvent(new ClientClaimAddedEvent(request.ClientId, claim.Id, claim.Type, claim.Value));
                return true;
            }

            return false;
        }
    }
}
