using Microsoft.EntityFrameworkCore;
using Proarch.TechBatchTask.Core.Domain.Common;
using Proarch.TechBatchTask.Core.Domain.Models;
using Proarch.TechBatchTask.Infrastructure.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proarch.TechBatchTask.Infrastructure.Data.Common
{
    public class TechBatchTaskDbContext : DbContext
    {
        public TechBatchTaskDbContext(DbContextOptions<TechBatchTaskDbContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ItemModelConfiguration());
            builder.ApplyConfiguration(new LedgerModelConfiguration());
        }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<LedgerModel> Ledgers { get; set; }



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
                    entity.CreatedAt = DateTime.Now;
                    //entity.CreatedBy = _userService.User;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Deleted))
            {
                if (entry.Entity is IModified entity)
                {
                    entity.LastModifiedAt = DateTime.Now;
                    //entity.LastModifiedBy = _userService.User;
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
