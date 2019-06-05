using IdentityServer4.Admin.Domain.Core.Events;
using IdentityServer4.Admin.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Data.Repositories
{
    public class EventStoreRepository : IEventStoreRepository
    {
        public Task<List<StoredEvent>> All(string username)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Store(StoredEvent theEvent)
        {
            throw new NotImplementedException();
        }
    }
}
