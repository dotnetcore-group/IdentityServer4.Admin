using IdentityServer4.Admin.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Domain.Interfaces
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        Task<List<StoredEvent>> All(string username);
    }
}
