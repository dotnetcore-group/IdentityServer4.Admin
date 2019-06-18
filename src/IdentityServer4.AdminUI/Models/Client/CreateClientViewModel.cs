using IdentityServer4.Admin.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.AdminUI.Models.Client
{
    public class CreateClientViewModel
    {
        [Required]
        public string ClientId { get; set; }
        [Required]
        public string ClientName { get; set; }
        public string ClientUri { get; set; }
        public string LogoUri { get; set; }
        public string Description { get; set; }
        public int ClientTypeId { get; set; } = ClientType.Empty.Id;

        public IList<ClientTypeViewModel> ClientTypes => new List<ClientTypeViewModel>
        {
            new ClientTypeViewModel(ClientType.Empty.Id, ClientType.Empty.Name, "Default", "Empty", ""),
            new ClientTypeViewModel(ClientType.WebImplicit.Id, ClientType.WebImplicit.Name, "Implicity Flow", "Web App (MVC)", ""),
            new ClientTypeViewModel(ClientType.WebHybrid.Id, ClientType.WebHybrid.Name, "Hybird Flow", "Web App (MVC)", ""),
            new ClientTypeViewModel(ClientType.Spa.Id, ClientType.Spa.Name, "Implicity Flow", "Single Page Application", ""),
            new ClientTypeViewModel(ClientType.Native.Id, ClientType.Native.Name, "Hybird Flow", "Nactive Application", ""),
            new ClientTypeViewModel(ClientType.Machine.Id, ClientType.Machine.Name, "Resource Owner Password & Client Credentials flow", "Machine", ""),
            new ClientTypeViewModel(ClientType.Device.Id, ClientType.Device.Name, "Device Flow", "Devices", ""),
        };
    }

    public class ClientTypeViewModel
    {
        public ClientTypeViewModel(int id, string name, string description, string displayName, string icon)
        {
            Id = id;
            Name = name;
            DisplayName = displayName;
            Description = description;
            Icon = icon;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
