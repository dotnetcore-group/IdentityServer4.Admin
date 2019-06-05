using IdentityServer4.Admin.Domain.Core.Events;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Admin.Identity.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Data.EventSourcing
{
    public class DbEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly SystemUser _user;

        public DbEventStore(IEventStoreRepository eventStoreRepository, SystemUser user)
        {
            _eventStoreRepository = eventStoreRepository;
            _user = user;
        }

        public void Save<T>(T @event) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(@event);

            var storedEvent = new StoredEvent(
                @event,
                serializedData,
                _user.Username);

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
