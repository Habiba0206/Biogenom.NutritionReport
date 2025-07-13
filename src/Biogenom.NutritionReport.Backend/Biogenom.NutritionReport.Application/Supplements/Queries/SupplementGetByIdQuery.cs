using Biogenom.NutritionReport.Application.Supplements.Models;
using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Application.Supplements.Queries;

public record SupplementGetByIdQuery : IQuery<SupplementGetDto?>
{
    public Guid SupplementId { get; set; }
}