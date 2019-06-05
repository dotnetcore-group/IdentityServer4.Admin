using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Core.Events
{
    public interface IEventHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}
