using Biogenom.NutritionReport.Application.PersonalizedIntakes.Commands;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.PersonalizedIntakes.Validators;

public class PersonalizedIntakeCreateCommandValidator : AbstractValidator<PersonalizedIntakeCreateCommand>
{
    public PersonalizedIntakeCreateCommandValidator()
    {
        RuleFor(x => x.PersonalizedIntakeCreateUpdateDto)
            .NotNull().WithMessage("PersonalizedIntakeDto cannot be null.")
            .SetValidator(new PersonalizedIntakeValidator());
    }
}