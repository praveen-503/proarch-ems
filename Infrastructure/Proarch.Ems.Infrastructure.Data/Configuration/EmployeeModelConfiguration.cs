using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Common;

namespace Proarch.Ems.Infrastructure.Data.Configuration
{
    class EmployeeModelConfiguration : AuditModelTypeConfiuration<EmployeeModel>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<EmployeeModel> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Password).IsRequired();
            builder.HasQueryFilter(x => !x.IsDelete);
            builder.ToTable("Employees");
            builder.HasOne<UserStoryModel>(s => s.UserStory)
                .WithOne(ad => ad.Employee)
                .HasForeignKey<UserStoryModel>(ad => ad.EmployeeId);
        }
    }
}
