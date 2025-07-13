namespace Biogenom.NutritionReport.Application.Benefits.Models;

public class BenefitCreateUpdateDto
{
    public Guid? Id { get; set; }
    public Guid ReportId { get; set; }

    public string Text { get; set; } = default!;
}
