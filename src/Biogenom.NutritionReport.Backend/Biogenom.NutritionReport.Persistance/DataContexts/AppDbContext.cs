using Biogenom.NutritionReport.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.NutritionReport.Persistence.DataContexts;

public class AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Benefit> Benefits => Set<Benefit>();
    public DbSet<NutrientConsumption> NutrientConsumptions => Set<NutrientConsumption>();
    public DbSet<PersonalizedIntake> PersonalizedIntakes => Set<PersonalizedIntake>();
    public DbSet<Report> Reports => Set<Report>();
    public DbSet<Supplement> Supplements => Set<Supplement>();
}
