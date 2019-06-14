using IdentityServer4.Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Data.EntityConfigurations
{
    public class UserLoginLogModelConfiguration : IEntityTypeConfiguration<UserLoginLog>
    {
        public void Configure(EntityTypeBuilder<UserLoginLog> builder)
        {
            builder.ToTable("UserLoginLogs");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Uid)
                .IsRequired(true);
            builder.HasIndex(l => l.Uid);

            builder.Property(l => l.IP)
                .HasMaxLength(50);

            builder.Property(l => l.OS)
                .HasMaxLength(50);

            builder.Property(l => l.Device)
                .HasMaxLength(50);

            builder.Property(l => l.LoginTime)
                .IsRequired(true);
        }
    }
}
