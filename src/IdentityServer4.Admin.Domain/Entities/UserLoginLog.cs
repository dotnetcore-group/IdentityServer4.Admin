using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Entities
{
    public class UserLoginLog
    {
        public long Id { get; set; }
        public long Uid { get; set; }
        public string Browser { get; set; }
        public string IP { get; set; }
        public string OS { get; set; }
        public string Device { get; set; }
        public DateTime LoginTime { get; set; }
    }
}
