using IdentityServer4.EntityFramework.Entities;
using SmartSql.DyRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Interfaces.DyRepositories
{
    public interface IClientRepository : IRepository<Client, int>, IRepositoryAsync<Client, int>
    {
    }
}
