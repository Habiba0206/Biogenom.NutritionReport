using Biogenom.NutritionReport.Application.NutrientConsumptions.Models;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Application.NutrientConsumptions.Commands;

public record NutrientConsumptionUpdateCommand : ICommand<NutrientConsumptionCreateUpdateDto>
{
    public NutrientConsumptionCreateUpdateDto NutrientConsumptionCreateUpdateDto { get; set; }
}