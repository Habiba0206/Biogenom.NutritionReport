namespace Biogenom.NutritionReport.Application.PersonalizedIntakes.Models;

public class PersonalizedIntakePatchDto
{
    public Guid Id  { get; set; }
    public Guid? ReportId { get; set; }

    public string? NutrientName { get; set; }
    public double? NewValue { get; set; }
    public string? Unit { get; set; }
    public string? Source { get; set; }
}
