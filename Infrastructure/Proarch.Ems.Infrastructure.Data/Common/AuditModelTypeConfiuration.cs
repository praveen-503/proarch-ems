using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proarch.Ems.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Infrastructure.Data.Common
{
    class AuditModelTypeConfiuration
    {
    }
    abstract class AuditModelTypeConfiuration<TModel> : IEntityTypeConfiguration<TModel>
       where TModel : AuditModel
    {
        public void Configure(EntityTypeBuilder<TModel> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(p => p.CreatedBy);
            builder.Property(p => p.CreatedAt).HasColumnType("TIMESTAMP"); 
            builder.Property(p => p.LastModifiedAt).HasColumnType("TIMESTAMP");
            builder.Property(p => p.LastModifiedBy);
            ConfigureEntity(builder);
        }

        protected abstract void ConfigureEntity(EntityTypeBuilder<TModel> builder);
    }
}
