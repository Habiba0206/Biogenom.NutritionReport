using Biogenom.NutritionReport.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.NutritionReport.Persistence.EntityConfigurations;

public sealed class BenefitConfiguration : IEntityTypeConfiguration<Benefit>
{
    public void Configure(EntityTypeBuilder<Benefit> builder)
    {
        builder.ToTable("benefits");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Text)
               .HasMaxLength(300)
               .IsRequired();

        builder.HasIndex(b => new { b.ReportId, b.Text })
               .IsUnique();

        builder.HasOne(b => b.Report)
               .WithMany(r => r.Benefits)
               .HasForeignKey(b => b.ReportId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}