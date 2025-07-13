using Biogenom.NutritionReport.Application.Benefits.Models;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Application.Benefits.Commands;

public record BenefitPatchCommand : ICommand<BenefitPatchDto>
{
    public BenefitPatchDto BenefitPatchDto { get; set; } = null!;
}