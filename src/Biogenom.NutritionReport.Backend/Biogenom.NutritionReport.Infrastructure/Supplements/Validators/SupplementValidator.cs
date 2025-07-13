using Biogenom.NutritionReport.Application.Supplements.Models;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.Supplements.Validators;

public class SupplementValidator : AbstractValidator<SupplementCreateUpdateDto>
{
    public SupplementValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Supplement name is required.");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Image URL is required.")
            .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
            .WithMessage("Image URL must be valid.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.");
    }
}