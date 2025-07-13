namespace Biogenom.NutritionReport.Application.PersonalizedIntakes.Models;

public class PersonalizedIntakeCreateUpdateDto
{
    public Guid? Id { get; set; }
    public Guid ReportId { get; set; }

    public string NutrientName { get; set; } = default!;
    public double NewValue { get; set; }
    public string Unit { get; set; } = default!;
    public string Source { get; set; } = "Total";
}
