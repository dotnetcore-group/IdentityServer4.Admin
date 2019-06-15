using IdentityServer4.Admin.Domain.Core.Events;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using UAParser;

namespace IdentityServer4.Admin.Domain.Events.User
{
    /// <summary>
    /// user login succes event
    /// </summary>
    public class UserLoggedInEvent : Event
    {
        public long Uid { get; set; }
        public string IP { get; set; }
        public string Browser { get; set; }
        public string OS { get; set; }
        public string Device { get; set; }
        public DateTime LoginTime { get; set; }

        public UserLoggedInEvent(long uid, HttpContext httpContext)
        {
            AggregateId = uid.ToString();
            Uid = uid;
            IP = httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            LoginTime = DateTime.UtcNow;

            SetUserAgentInfo(httpContext);
        }

        private void SetUserAgentInfo(HttpContext httpContext)
        {
            var clientInfo = GetClientInfo(httpContext);

            if (clientInfo != null)
            {
                Browser = clientInfo.UA.Family;
                OS = clientInfo.OS.Family;
                Device = clientInfo.Device.Family;
            }
        }

        private ClientInfo GetClientInfo(HttpContext context)
        {
            var userAgent = context.Request.Headers["User-Agent"].FirstOrDefault();
            if (userAgent != null)
            {
                var clientInfo = Parser.GetDefault().Parse(userAgent);
                return clientInfo;
            }
            return null;
        }
    }
}
