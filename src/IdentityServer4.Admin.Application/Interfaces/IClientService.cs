using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Application.Interfaces
{
    public interface IClientService
    {
        Task<IList<Client>> GetClientsAsync();
    }
}
