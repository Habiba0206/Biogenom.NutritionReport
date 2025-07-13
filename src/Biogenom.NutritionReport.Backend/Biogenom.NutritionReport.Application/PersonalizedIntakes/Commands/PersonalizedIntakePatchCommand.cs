using Biogenom.NutritionReport.Application.PersonalizedIntakes.Models;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Application.PersonalizedIntakes.Commands;

public record PersonalizedIntakePatchCommand : ICommand<PersonalizedIntakePatchDto>
{
    public PersonalizedIntakePatchDto PersonalizedIntakePatchDto { get; set; } = null!;
}