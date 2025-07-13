using Biogenom.NutritionReport.Application.PersonalizedIntakes.Commands;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.PersonalizedIntakes.Validators;

public class PersonalizedIntakePatchCommandValidator : AbstractValidator<PersonalizedIntakePatchCommand>
{
    public PersonalizedIntakePatchCommandValidator()
    {
        RuleFor(x => x.PersonalizedIntakePatchDto)
            .NotNull().WithMessage("Patch DTO must not be null.");

        RuleFor(x => x.PersonalizedIntakePatchDto.Id)
            .NotEmpty().WithMessage("Id is required for patching.");
    }
}