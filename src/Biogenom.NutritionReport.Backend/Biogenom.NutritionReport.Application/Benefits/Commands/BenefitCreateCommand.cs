using Biogenom.NutritionReport.Application.Benefits.Models;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Application.Benefits.Commands;

public record BenefitCreateCommand : ICommand<BenefitCreateUpdateDto>
{
    public BenefitCreateUpdateDto BenefitCreateUpdateDto { get; set; }
}