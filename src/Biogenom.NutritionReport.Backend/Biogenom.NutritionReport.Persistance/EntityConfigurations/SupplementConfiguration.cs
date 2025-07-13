using Biogenom.NutritionReport.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.NutritionReport.Persistence.EntityConfigurations;

public sealed class SupplementConfiguration : IEntityTypeConfiguration<Supplement>
{
    public void Configure(EntityTypeBuilder<Supplement> builder)
    {
        builder.ToTable("supplements");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
               .HasMaxLength(120)
               .IsRequired();

        builder.Property(s => s.ImageUrl)
               .HasMaxLength(500);

        builder.Property(s => s.Description)
               .HasMaxLength(500);

        builder.HasIndex(s => new { s.ReportId, s.Name })
               .IsUnique();

        builder.HasOne(s => s.Report)
               .WithMany(r => r.Supplements)
               .HasForeignKey(s => s.ReportId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}