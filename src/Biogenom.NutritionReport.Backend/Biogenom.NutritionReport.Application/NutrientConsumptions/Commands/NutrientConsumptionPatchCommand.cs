using Biogenom.NutritionReport.Application.NutrientConsumptions.Models;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Application.NutrientConsumptions.Commands;

public record NutrientConsumptionPatchCommand : ICommand<NutrientConsumptionPatchDto>
{
    public NutrientConsumptionPatchDto NutrientConsumptionPatchDto { get; set; } = null!;
}