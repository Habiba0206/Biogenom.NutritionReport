using Biogenom.NutritionReport.Application.Benefits.Models;
using Biogenom.NutritionReport.Application.NutrientConsumptions.Models;
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Models;
using Biogenom.NutritionReport.Application.Supplements.Models;
using Biogenom.NutritionReport.Domain.Entities;

namespace Biogenom.NutritionReport.Application.Reports.Models;

public class ReportGetDto
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public ICollection<NutrientConsumptionCreateUpdateDto> NutrientConsumptions { get; set; } = new List<NutrientConsumptionCreateUpdateDto>();
    public ICollection<PersonalizedIntakeCreateUpdateDto> PersonalizedIntakes { get; set; } = new List<PersonalizedIntakeCreateUpdateDto>();
    public ICollection<SupplementCreateUpdateDto> Supplements { get; set; } = new List<SupplementCreateUpdateDto>();
    public ICollection<BenefitCreateUpdateDto> Benefits { get; set; } = new List<BenefitCreateUpdateDto>();
}
