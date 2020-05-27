using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proarch.Ems.Core.Domain.Common;

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
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.CreatedBy);
            builder.Property(p => p.CreatedAt).HasColumnType("TIMESTAMP");
            builder.Property(p => p.LastModifiedAt).HasColumnType("TIMESTAMP");
            builder.Property(p => p.LastModifiedBy);
            ConfigureEntity(builder);
        }

        protected abstract void ConfigureEntity(EntityTypeBuilder<TModel> builder);
    }
}
