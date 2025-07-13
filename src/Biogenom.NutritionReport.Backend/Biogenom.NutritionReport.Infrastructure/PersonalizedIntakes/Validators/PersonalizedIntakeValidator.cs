using Biogenom.NutritionReport.Application.PersonalizedIntakes.Models;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.PersonalizedIntakes.Validators;

public class PersonalizedIntakeValidator : AbstractValidator<PersonalizedIntakeCreateUpdateDto>
{
    public PersonalizedIntakeValidator()
    {
        RuleFor(x => x.NutrientName)
            .NotEmpty().WithMessage("Nutrient name is required.");

        RuleFor(x => x.Unit)
            .NotEmpty().WithMessage("Unit is required.");

        RuleFor(x => x.NewValue)
            .GreaterThanOrEqualTo(0).WithMessage("New value must be non‑negative.");

        RuleFor(x => x.Source)
            .NotEmpty().WithMessage("Source is required.")
            .Must(s => s is "Food" or "Kit" or "Total")
            .WithMessage("Source must be Food, Kit, or Total.");
    }
}