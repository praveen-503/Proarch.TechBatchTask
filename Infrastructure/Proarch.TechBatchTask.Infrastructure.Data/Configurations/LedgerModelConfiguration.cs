using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proarch.TechBatchTask.Core.Domain.Models;

namespace Proarch.TechBatchTask.Infrastructure.Data.Configurations
{
    internal class LedgerModelConfiguration : AuditModelTypeConfiuration<LedgerModel>
    {
        //void IEntityTypeConfiguration<LedgerModel>.Configure(EntityTypeBuilder<LedgerModel> builder)
        //{
        //    builder.HasKey(l => l.Id);
        //    builder.Property(l => l.Date).HasColumnType("timestamp");
        //    builder
        //                .HasMany<ItemModel>(g => g.Items)
        //                .WithOne(s => s.Ledger)
        //                .HasForeignKey(s => s.LedgerId);
        //}
        protected override void ConfigureEntity(EntityTypeBuilder<LedgerModel> builder)
        {
            builder.ToTable("Ledgers");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Date).HasColumnType("timestamp");
            builder.HasMany<ItemModel>(g => g.Items)
                        .WithOne(s => s.Ledger)
                        .HasForeignKey(s => s.LedgerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
