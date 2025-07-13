using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Application.Supplements.Commands;

public record SupplementDeleteByIdCommand : ICommand<bool>
{
    public Guid SupplementId { get; set; }
}