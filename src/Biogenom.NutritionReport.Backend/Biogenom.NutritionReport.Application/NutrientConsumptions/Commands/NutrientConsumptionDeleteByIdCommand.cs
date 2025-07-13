using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Application.NutrientConsumptions.Commands;

public record NutrientConsumptionDeleteByIdCommand : ICommand<bool>
{
    public Guid NutrientConsumptionId { get; set; }
}