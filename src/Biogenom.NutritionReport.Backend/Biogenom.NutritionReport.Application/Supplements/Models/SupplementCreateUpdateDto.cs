namespace Biogenom.NutritionReport.Application.Supplements.Models;

public class SupplementCreateUpdateDto
{
    public Guid? Id { get; set; }
    public Guid ReportId { get; set; }

    public string Name { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public string Description { get; set; } = default!;
}
