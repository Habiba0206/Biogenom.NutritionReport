using Biogenom.NutritionReport.Application.Supplements.Models;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Application.Supplements.Commands;

public record SupplementUpdateCommand : ICommand<SupplementCreateUpdateDto>
{
    public SupplementCreateUpdateDto SupplementCreateUpdateDto { get; set; }
}