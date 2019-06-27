using IdentityServer4.Admin.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentityServer4.Admin.Domain.Models
{
    public class ClientType : Enumeration
    {
        public static ClientType Empty => new EmptyClientType();
        public static ClientType WebImplicit => new WebImplicitClientType();
        public static ClientType WebHybrid => new WebHybridClientType();
        public static ClientType Spa => new SpaClientType();
        public static ClientType Native => new NativeClientType();
        public static ClientType Machine => new MachineClientType();
        public static ClientType Device => new DeviceClientType();

        public static IEnumerable<ClientType> List() =>
            new[] { Empty, WebImplicit, WebHybrid, Spa, Native, Machine, Device };


        public ClientType(int id, string name) : base(id, name)
        {
        }

        public static ClientType From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new Exception($"Possible values for OrderStatus: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        #region Client Types
        private class EmptyClientType : ClientType
        {
            public EmptyClientType() : base(0, "Empty") { }
        }
        private class WebImplicitClientType : ClientType
        {
            public WebImplicitClientType() : base(1, "WebImplicit") { }
        }
        private class WebHybridClientType : ClientType
        {
            public WebHybridClientType() : base(2, "WebHybrid") { }
        }
        private class SpaClientType : ClientType
        {
            public SpaClientType() : base(3, "Spa") { }
        }
        private class NativeClientType : ClientType
        {
            public NativeClientType() : base(4, "Native") { }
        }
        private class MachineClientType : ClientType
        {
            public MachineClientType() : base(5, "Machine") { }
        }
        private class DeviceClientType : ClientType
        {
            public DeviceClientType() : base(6, "Device") { }
        }
        #endregion
    }
}
