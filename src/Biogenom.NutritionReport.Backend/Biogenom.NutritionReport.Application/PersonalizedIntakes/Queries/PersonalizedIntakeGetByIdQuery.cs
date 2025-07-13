using Biogenom.NutritionReport.Application.PersonalizedIntakes.Models;
using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Application.PersonalizedIntakes.Queries;

public record PersonalizedIntakeGetByIdQuery : IQuery<PersonalizedIntakeGetDto?>
{
    public Guid PersonalizedIntakeId { get; set; }
}