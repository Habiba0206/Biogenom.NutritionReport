using Biogenom.NutritionReport.Application.PersonalizedIntakes.Models;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Application.PersonalizedIntakes.Commands;

public record PersonalizedIntakeCreateCommand : ICommand<PersonalizedIntakeCreateUpdateDto>
{
    public PersonalizedIntakeCreateUpdateDto PersonalizedIntakeCreateUpdateDto { get; set; }
}