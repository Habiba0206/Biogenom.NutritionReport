using Biogenom.NutritionReport.Application.NutrientConsumptions.Models;
using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Application.NutrientConsumptions.Queries;

public record NutrientConsumptionGetByIdQuery : IQuery<NutrientConsumptionGetDto?>
{
    public Guid NutrientConsumptionId { get; set; }
}