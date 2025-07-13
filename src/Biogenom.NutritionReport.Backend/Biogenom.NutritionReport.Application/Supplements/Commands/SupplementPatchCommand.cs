using Biogenom.NutritionReport.Application.Supplements.Models;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Application.Supplements.Commands;

public record SupplementPatchCommand : ICommand<SupplementPatchDto>
{
    public SupplementPatchDto SupplementPatchDto { get; set; } = null!;
}