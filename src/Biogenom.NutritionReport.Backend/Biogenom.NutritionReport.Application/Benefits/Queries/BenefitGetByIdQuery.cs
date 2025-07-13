using Biogenom.NutritionReport.Application.Benefits.Models;
using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Application.Benefits.Queries;

public record BenefitGetByIdQuery : IQuery<BenefitGetDto?>
{
    public Guid BenefitId { get; set; }
}