using Microsoft.EntityFrameworkCore;
using Proarch.Ems.Core.Application.Services;
using Proarch.Ems.Core.Domain.Common;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Proarch.Ems.Infrastructure.Data.Common
{
    public class EmsDbContext : DbContext
    {
        private readonly IUserService _userService;

        public EmsDbContext(DbContextOptions<EmsDbContext> options, IUserService userService)
            : base(options)
        {
            _userService = userService;
        }

        public DbSet<ClientModel> ClientModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientModelConfiguration());
        }

        public override int SaveChanges()
        {
            Audit();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            Audit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            Audit();
            return base.SaveChangesAsync(cancellationToken);
        }

        protected void Audit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
            {
                if (entry.Entity is ICreated entity)
                {
                    entity.CreatedAt = DateTimeOffset.Now;
                    entity.CreatedBy = _userService.User;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Deleted))
            {
                if (entry.Entity is IModified entity)
                {
                    entity.LastModifiedAt = DateTimeOffset.Now;
                    entity.LastModifiedBy = _userService.User;
                }

                if (entry.Entity is ISoftDelete entity2)
                {
                    if (entry.State == EntityState.Deleted)
                    {
                        entity2.IsDelete = true;
                    }
                }

                entry.State = EntityState.Modified;
            }
        }
    }
}
