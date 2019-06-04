using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Infrastructures.Data.Database
{
    /// <summary>
    /// AspNetCore Identity DbContext
    /// </summary>
    public class ApplicationIdentityDbContext: IdentityDbContext
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // todo : config table
        }
    }
}
