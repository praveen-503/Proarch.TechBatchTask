using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proarch.TechBatchTask.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.TechBatchTask.Infrastructure.Data.Configurations
{
    internal class ItemModelConfiguration : AuditModelTypeConfiuration<ItemModel>
    {
        //void IEntityTypeConfiguration<ItemModel>.Configure(EntityTypeBuilder<ItemModel> builder)
        //{
        //    builder.Property(i => i.Name).IsRequired();
        //    builder.Property(i => i.Price);
        //    builder.HasOne<LedgerModel>(i => i.Ledger)
        //        .WithMany(l => l.Items)
        //        .HasForeignKey(i => i.LedgerId);
        //}
        protected override void ConfigureEntity(EntityTypeBuilder<ItemModel> builder)
        {
            builder.ToTable("Iems");
            builder.Property(i => i.Name).IsRequired();
            builder.Property(i => i.Price);
            builder.HasOne<LedgerModel>(i => i.Ledger)
                .WithMany(l => l.Items)
                .HasForeignKey(i => i.LedgerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
/* 
  modelBuilder.Entity<Student>()
            .HasOne<Grade>(s => s.Grade)
            .WithMany(g => g.Students)
            .HasForeignKey(s => s.CurrentGradeId);*/

