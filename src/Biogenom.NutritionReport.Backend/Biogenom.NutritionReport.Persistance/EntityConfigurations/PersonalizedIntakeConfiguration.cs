using Biogenom.NutritionReport.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.NutritionReport.Persistence.EntityConfigurations;

public sealed class PersonalizedIntakeConfiguration : IEntityTypeConfiguration<PersonalizedIntake>
{
    public void Configure(EntityTypeBuilder<PersonalizedIntake> builder)
    {
        builder.ToTable("personalized_intakes");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.NutrientName)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(p => p.Unit)
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(p => p.NewValue).IsRequired();

        builder.Property(p => p.Source)
               .HasMaxLength(10)
               .IsRequired();

        builder.HasIndex(p => new { p.ReportId, p.NutrientName, p.Source })
               .IsUnique();

        builder.HasOne(p => p.Report)
               .WithMany(r => r.PersonalizedIntakes)
               .HasForeignKey(p => p.ReportId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}