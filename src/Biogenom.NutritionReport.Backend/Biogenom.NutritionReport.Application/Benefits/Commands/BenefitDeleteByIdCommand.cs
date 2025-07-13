using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Application.Benefits.Commands;

public record BenefitDeleteByIdCommand : ICommand<bool>
{
    public Guid BenefitId { get; set; }
}