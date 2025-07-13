using Biogenom.NutritionReport.Domain.Entities;
using Biogenom.NutritionReport.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.NutritionReport.Api.Data;

public static class SeedDataExtensions
{
    public static async ValueTask InitializeSeedAsync(this IServiceProvider provider)
    {
        var db = provider.GetRequiredService<AppDbContext>();

        if (!await db.Reports.AnyAsync())
            await db.SeedNutritionDemoAsync();

        if (db.ChangeTracker.HasChanges())
            await db.SaveChangesAsync();
    }

    private static async ValueTask SeedNutritionDemoAsync(this AppDbContext db)
    {
        var report = new Report
        {
            Id = Guid.NewGuid(),
            CreatedTime = DateTime.UtcNow,

            NutrientConsumptions =
            {
                new() { Name = "Vitamin C", Unit = "mg",  CurrentValue = 42.4, RecommendedMin = 100, RecommendedMax = 100, IsDeficient = true  },
                new() { Name = "Vitamin D", Unit = "µg",  CurrentValue = 6.1,  RecommendedMin = 15,  RecommendedMax = 15,  IsDeficient = true  },
                new() { Name = "Magnesium", Unit = "mg",  CurrentValue = 250,  RecommendedMin = 400, RecommendedMax = 420, IsDeficient = true  },
                new() { Name = "Water",     Unit = "L",   CurrentValue = 2.8,  RecommendedMin = 2.5, RecommendedMax = 3.0, IsDeficient = false }
            },

            PersonalizedIntakes =
            {
                new() { NutrientName = "Vitamin C", Unit = "mg", NewValue = 120, Source = "Total" },
                new() { NutrientName = "Vitamin D", Unit = "µg", NewValue = 25,  Source = "Total" }
            },

            Supplements =
            {
                new() { Name = "E‑Smart", ImageUrl = "https://via.placeholder.com/120x160?text=E‑Smart", Description = "Immunity support complex." },
                new() { Name = "Mag‑Max", ImageUrl = "https://via.placeholder.com/120x160?text=Mag‑Max", Description = "High‑absorption magnesium." }
            },

            Benefits =
            {
                new() { Text = "Eliminates vitamin and mineral deficiencies." },
                new() { Text = "Improves nutrient absorption efficiency." }
            }
        };

        await db.Reports.AddAsync(report);
    }
}