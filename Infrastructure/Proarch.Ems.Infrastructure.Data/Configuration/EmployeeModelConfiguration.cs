using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Infrastructure.Data.Configuration
{
    class  EmployeeModelConfiguration : AuditModelTypeConfiuration<EmployeeModel>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<EmployeeModel> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Password).IsRequired();
            builder.HasQueryFilter(x => !x.IsDelete);
            builder.ToTable("Employees");
        }
    }
}
