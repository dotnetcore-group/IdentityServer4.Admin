using IdentityServer4.Admin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Interfaces
{
    public interface ILoginLogRepository : IRepository<UserLoginLog>, IAsyncRepository<UserLoginLog>
    {
    }
}
