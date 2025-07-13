namespace Biogenom.NutritionReport.Application.Benefits.Models;

public class BenefitPatchDto
{
    public Guid Id { get; set; }
    public Guid? ReportId { get; set; }

    public string? Text { get; set; } 
}