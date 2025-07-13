using Biogenom.NutritionReport.Application.PersonalizedIntakes.Commands;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.PersonalizedIntakes.Validators;

public class PersonalizedIntakeUpdateCommandValidator : AbstractValidator<PersonalizedIntakeUpdateCommand>
{
    public PersonalizedIntakeUpdateCommandValidator()
    {
        RuleFor(x => x.PersonalizedIntakeCreateUpdateDto)
            .NotNull().WithMessage("PersonalizedIntake DTO cannot be null.")
            .SetValidator(new PersonalizedIntakeValidator());
    }
}