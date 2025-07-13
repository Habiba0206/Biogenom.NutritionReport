using Biogenom.NutritionReport.Application.Supplements.Models;
using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Application.Supplements.Queries;

public record SupplementGetQuery : IQuery<ICollection<SupplementGetDto>>
{
    public SupplementFilter SupplementFilter { get; set; }
}