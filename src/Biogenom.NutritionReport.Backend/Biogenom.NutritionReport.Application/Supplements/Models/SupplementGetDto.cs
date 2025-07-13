using Biogenom.NutritionReport.Application.Reports.Models;
using Biogenom.NutritionReport.Domain.Entities;

namespace Biogenom.NutritionReport.Application.Supplements.Models;

public class SupplementGetDto
{
    public Guid Id  { get; set; }
    public Guid ReportId { get; set; }

    public string Name { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public string Description { get; set; } = default!;

    public ReportCreateUpdateDto Report { get; set; } = default!;
}
