using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proarch.Ems.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Proarch.Ems.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Infrastructure.Data.Configuration
{
    class ClientModelConfiguration : AuditModelTypeConfiuration<ClientModel>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<ClientModel> builder)
        {
            builder.Property(p => p.Name);
            builder.Property(p => p.IsExisted);
            builder.HasQueryFilter(x => !x.IsDelete);
            //builder.ToTable("TodoItem");
        }
    }
}
