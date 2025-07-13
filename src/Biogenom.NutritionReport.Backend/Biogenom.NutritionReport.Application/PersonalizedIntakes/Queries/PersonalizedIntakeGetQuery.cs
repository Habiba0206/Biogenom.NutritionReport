using Biogenom.NutritionReport.Application.PersonalizedIntakes.Models;
using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Application.PersonalizedIntakes.Queries;

public record PersonalizedIntakeGetQuery : IQuery<ICollection<PersonalizedIntakeGetDto>>
{
    public PersonalizedIntakeFilter PersonalizedIntakeFilter { get; set; }
}