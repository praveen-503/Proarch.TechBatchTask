using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proarch.TechBatchTask.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.TechBatchTask.Infrastructure.Data.Configurations
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
            builder.Property(p => p.CreatedAt).HasColumnType("TIMESTAMP");
            builder.Property(p => p.LastModifiedAt).HasColumnType("TIMESTAMP");
            ConfigureEntity(builder);
        }

        protected abstract void ConfigureEntity(EntityTypeBuilder<TModel> builder);
    }
}
