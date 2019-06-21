using IdentityServer4.Admin.Domain.Models;
using IdentityServer4.Admin.Domain.Validations.Client;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using System;

namespace IdentityServer4.Admin.Domain.Commands.Client
{
    public class CreateClientCommand : ClientCommand
    {
        public ClientType ClientType { get; private set; }

        public CreateClientCommand(string clientId, string clientName, string clientUri, string description, string logoUri, ClientType clientType)
        {
            Client = new IdentityServer4.Models.Client
            {
                ClientId = clientId,
                ClientName = clientName,
                ClientUri = clientUri,
                LogoUri = logoUri,
                Description = description
            };
            ClientType = clientType;
        }

        public IdentityServer4.EntityFramework.Entities.Client GetClientEntity()
        {
            var configuration = new ClientConfigurationContext(ClientType);
            configuration.Configure(Client);
            return Client.ToEntity();
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    #region Client Configuration Strategy
    public interface IClientConfigurationStrategy
    {
        void Configure(IdentityServer4.Models.Client client);
    }

    public class WebImplicitClientConfigurationStrategy : IClientConfigurationStrategy
    {
        public void Configure(IdentityServer4.Models.Client client)
        {
            client.AllowedGrantTypes = GrantTypes.Implicit;
            client.AllowAccessTokensViaBrowser = true;
        }
    }
    public class WebHybridClientConfigurationStrategy : IClientConfigurationStrategy
    {
        public void Configure(IdentityServer4.Models.Client client)
        {
            client.AllowedGrantTypes = GrantTypes.Hybrid;
        }
    }
    public class DeviceClientConfigurationStrategy : IClientConfigurationStrategy
    {
        public void Configure(IdentityServer4.Models.Client client)
        {
            client.AllowedGrantTypes = GrantTypes.DeviceFlow;
            client.RequireClientSecret = false;
            client.AllowOfflineAccess = true;
        }
    }
    public class SpaClientConfigurationStrategy : IClientConfigurationStrategy
    {
        public void Configure(IdentityServer4.Models.Client client)
        {
            client.AllowedGrantTypes = GrantTypes.Implicit;
            client.AllowAccessTokensViaBrowser = true;
        }
    }
    public class NativeClientConfigurationStrategy : IClientConfigurationStrategy
    {
        public void Configure(IdentityServer4.Models.Client client)
        {
            client.AllowedGrantTypes = GrantTypes.Hybrid;
        }
    }
    public class MachineClientConfigurationStrategy : IClientConfigurationStrategy
    {
        public void Configure(IdentityServer4.Models.Client client)
        {
            client.AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials;
        }
    }

    public class ClientConfigurationContext
    {
        private readonly ClientType _clientType;
        public ClientConfigurationContext(ClientType clientType)
        {
            _clientType = clientType;
        }

        public void Configure(IdentityServer4.Models.Client client)
        {
            IClientConfigurationStrategy strategy = null;
            if (_clientType.Id == ClientType.WebImplicit.Id)
            {
                strategy = new WebImplicitClientConfigurationStrategy();
            }
            else if (_clientType.Id == ClientType.WebHybrid.Id)
            {
                strategy = new WebHybridClientConfigurationStrategy();
            }
            else if (_clientType.Id == ClientType.Device.Id)
            {
                strategy = new DeviceClientConfigurationStrategy();
            }
            else if (_clientType.Id == ClientType.Spa.Id)
            {
                strategy = new SpaClientConfigurationStrategy();
            }
            else if (_clientType.Id == ClientType.Native.Id)
            {
                strategy = new NativeClientConfigurationStrategy();
            }
            else if (_clientType.Id == ClientType.Machine.Id)
            {
                strategy = new MachineClientConfigurationStrategy();
            }
            else
            {
                throw new ArgumentException(nameof(_clientType.Id));
            }
            strategy?.Configure(client);
        }
    }
    #endregion
}
