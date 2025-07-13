using Biogenom.NutritionReport.Application.NutrientConsumptions.Models;
using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Application.NutrientConsumptions.Queries;

public record NutrientConsumptionGetQuery : IQuery<ICollection<NutrientConsumptionGetDto>>
{
    public NutrientConsumptionFilter NutrientConsumptionFilter { get; set; }
}