using Biogenom.NutritionReport.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.NutritionReport.Persistence.EntityConfigurations;

public sealed class NutrientConsumptionConfiguration : IEntityTypeConfiguration<NutrientConsumption>
{
    public void Configure(EntityTypeBuilder<NutrientConsumption> builder)
    {
        builder.ToTable("nutrient_consumptions");

        builder.HasKey(n => n.Id);

        builder.Property(n => n.Name)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(n => n.Unit)
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(n => n.CurrentValue).IsRequired();
        builder.Property(n => n.RecommendedMin).IsRequired();
        builder.Property(n => n.RecommendedMax).IsRequired();
        builder.Property(n => n.IsDeficient).IsRequired();

        builder.HasIndex(n => new { n.ReportId, n.Name })
               .IsUnique();

        builder.HasOne(n => n.Report)
               .WithMany(r => r.NutrientConsumptions)
               .HasForeignKey(n => n.ReportId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
