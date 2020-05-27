﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Common;

namespace Proarch.Ems.Infrastructure.Data.Configuration
{
    class ClientModelConfiguration : AuditModelTypeConfiuration<ClientModel>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<ClientModel> builder)
        {
            builder.ToTable("Clients");
            builder.Property(p => p.Name);
            builder.Property(p => p.IsExisted);
            builder.HasQueryFilter(x => !x.IsDelete);
            builder
                .HasMany<ProjectModel>(g => g.Projects)
                .WithOne(s => s.Client)
                .HasForeignKey(s => s.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
