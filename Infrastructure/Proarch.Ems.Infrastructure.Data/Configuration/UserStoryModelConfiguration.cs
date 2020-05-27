using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Common;

namespace Proarch.Ems.Infrastructure.Data.Configuration
{
    internal class UserStoryModelConfiguration : AuditModelTypeConfiuration<UserStoryModel>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<UserStoryModel> builder)
        {
            builder.ToTable("UserStories1");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.IsRecurring);
            builder.Property(u => u.RecurringHours).HasColumnName("DefaultHours");

        }
    }
}
