using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Common;

namespace Proarch.Ems.Infrastructure.Data.Configuration
{
    class EmployeeProjectConfiguration : AuditModelTypeConfiuration<EmployeeProjectModel>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<EmployeeProjectModel> builder)
        {
            builder.ToTable("EmployeeProject");
            builder.HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

            builder.HasOne<EmployeeModel>(sc => sc.Employee)
                .WithMany(s => s.EmployeeProjects)
                .HasForeignKey(sc => sc.EmployeeId);


            builder.HasOne<ProjectModel>(sc => sc.Project)
                .WithMany(s => s.EmployeeProjects)
                .HasForeignKey(sc => sc.ProjectId);
        }
    }

}
