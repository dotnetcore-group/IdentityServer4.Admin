using IdentityServer4.Admin.Data.Database;
using IdentityServer4.Admin.Domain.Core.Events;
using IdentityServer4.Admin.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Data.Repositories
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly EventStoreContext _context;
        public EventStoreRepository(EventStoreContext context)
        {
            _context = context;
        }

        public Task<List<StoredEvent>> All(string username)
        {
            return (from e in _context.StoredEvent where e.User == username orderby e.Timestamp descending select e).ToListAsync();
        }

        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
