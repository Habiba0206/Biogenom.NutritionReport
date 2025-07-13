namespace Biogenom.NutritionReport.Application.Supplements.Models;

public class SupplementPatchDto
{
    public Guid Id  { get; set; }
    public Guid? ReportId { get; set; }

    public string? Name { get; set; } 
    public string? ImageUrl { get; set; } 
    public string? Description { get; set; } 
}
