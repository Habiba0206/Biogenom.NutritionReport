using Biogenom.NutritionReport.Domain.Common.Entities;

namespace Biogenom.NutritionReport.Domain.Entities;

public class Report : AuditableEntity
{
    public ICollection<NutrientConsumption> NutrientConsumptions { get; set; } = new List<NutrientConsumption>();
    public ICollection<PersonalizedIntake> PersonalizedIntakes { get; set; } = new List<PersonalizedIntake>();
    public ICollection<Supplement> Supplements { get; set; } = new List<Supplement>();
    public ICollection<Benefit> Benefits { get; set; } = new List<Benefit>();
}
