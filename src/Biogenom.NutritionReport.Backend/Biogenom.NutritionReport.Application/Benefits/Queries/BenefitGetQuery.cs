using Biogenom.NutritionReport.Application.Benefits.Models;
using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Application.Benefits.Queries;

public record BenefitGetQuery : IQuery<ICollection<BenefitGetDto>>
{
    public BenefitFilter BenefitFilter { get; set; }
}