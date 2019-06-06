using IdentityServer4.Admin.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Identity
{
    /// <summary>
    /// AspNetCore Identity DbContext
    /// </summary>
    public class AppIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationRole>().ToTable(TableNames.IdentityRoles);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable(TableNames.IdentityRoleClaims);
            builder.Entity<IdentityUserRole<Guid>>().ToTable(TableNames.IdentityUserRoles);

            builder.Entity<ApplicationUser>(b =>
            {
                b.ToTable(TableNames.IdentityUsers);

                b.HasIndex(u => u.Uid).IsUnique();
                b.Property(u => u.Nickname).HasMaxLength(100).IsUnicode().IsRequired(false);
                b.Property(u => u.Avatar).HasMaxLength(1000).IsRequired(false);
            });
            builder.Entity<IdentityUserLogin<Guid>>().ToTable(TableNames.IdentityUserLogins);
            builder.Entity<IdentityUserClaim<Guid>>().ToTable(TableNames.IdentityUserClaims);
            builder.Entity<IdentityUserToken<Guid>>().ToTable(TableNames.IdentityUserTokens);
        }
    }
}
