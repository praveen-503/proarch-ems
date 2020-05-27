using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Common;

namespace Proarch.Ems.Infrastructure.Data.Configuration
{
    internal class ProjectModelConfiuration : AuditModelTypeConfiuration<ProjectModel>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<ProjectModel> builder)
        {
            builder.ToTable("Projects");
            builder.Property(e => e.Name).IsRequired();
            builder.HasQueryFilter(x => !x.IsDelete);
            builder
           .HasOne<ClientModel>(s => s.Client)
           .WithMany(g => g.Projects)
           .HasForeignKey(s => s.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<UserStoryModel>(s => s.UserStory)
         .WithOne(ad => ad.Project)
         .HasForeignKey<UserStoryModel>(ad => ad.ProjectId);
        }
    }
}
